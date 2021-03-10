using CQRS.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.ObjectPartern.ProductObject.Commands
{
    public class UpdateStudentCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, int>
        {
            private readonly IApplicationContext _context;
            public UpdateStudentCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
            {
                var student = _context.Students.Where(a => a.Id == command.Id).FirstOrDefault();

                if (student == null)
                {
                    return default;
                }
                else
                {
                    student.Name = command.Name;
                    student.Address = command.Address;
                    student.Age = command.Age;
                    await _context.SaveChangesAsync();
                    return student.Id;
                }
            }
        }
    }
}
