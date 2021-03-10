using CQRS.Context;
using CQRS.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.ObjectPartern.ProductObject.Commands
{
    public class CreateStudentCommand : IRequest<Student>
    {
        public Student Student { get; set; }
        public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Student>
        {
            private readonly IApplicationContext _context;
            public CreateStudentCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<Student> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
            {
                var student = new Student();
                student.Name = command.Student.Name;
                student.Address = command.Student.Address;
                student.Age = command.Student.Age;
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return command.Student;
            }
        }
    }
}
