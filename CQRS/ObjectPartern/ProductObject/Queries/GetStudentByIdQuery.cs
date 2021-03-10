using CQRS.Context;
using CQRS.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.ObjectPartern.ProductObject.Queries
{
    public class GetStudentByIdQuery : IRequest<Student>
    {
        public int Id { get; set; }
        public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, Student>
        {
            private readonly IApplicationContext _context;
            public GetStudentByIdHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<Student> Handle(GetStudentByIdQuery query, CancellationToken cancellationToken)
            {
                var product = _context.Students.Where(a => a.Id == query.Id).FirstOrDefault();
                if (product == null) return null;
                return product;
            }
        }
    }
}
