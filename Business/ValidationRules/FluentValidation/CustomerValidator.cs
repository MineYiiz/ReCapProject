using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(ctm => ctm.CompanyName).NotEmpty();
            RuleFor(ctm => ctm.CompanyName).MinimumLength(2);
        }
    }
}
