using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Bussines.ValidationRules.FluentValidation
{
    public class GarbageValidator :AbstractValidator<Garbage>
    {
        public GarbageValidator()
        {
            RuleFor(G => G.Carbon).NotEmpty();
            RuleFor(G=> G.Type).NotEmpty();
            RuleFor(G => G.Carbon).GreaterThanOrEqualTo(1);
        }
    }
}
