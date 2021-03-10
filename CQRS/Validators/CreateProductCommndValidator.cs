using CQRS.ObjectPartern.ProductObject.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Validators
{
    public class CreateProductCommndValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateProductCommndValidator()
        {
            RuleFor(x => x.Student.Name).NotEmpty().WithMessage("Please enter the name").MinimumLength(5).WithMessage("Name – at least 5 Characters");
            RuleFor(x => x.Student.Address).NotEmpty().WithMessage("Please enter Student description").MinimumLength(5).WithMessage("Description – at least 5 Characters");
            RuleFor(x => x.Student.Age).NotEmpty().WithMessage("Please Enter rate ").InclusiveBetween(10, 50).WithMessage("Rate between 10 to 50");
        }
    }
}
