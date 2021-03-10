using CQRS.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.ObjectPartern.ProductObject.Commands
{
    public class DeleteStudentByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteStudentByIdCommandHandler : IRequestHandler<DeleteStudentByIdCommand, int>
        {
            private readonly IApplicationContext _context;
            public DeleteStudentByIdCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteStudentByIdCommand command, CancellationToken cancellationToken)
            {
                var product = await _context.Students.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (product == null) return default;
                _context.Students.Remove(product);
                await _context.SaveChangesAsync();
                return product.Id;
            }
        }
    }
}
