using FluentValidation;

namespace Domain.Commands.v1.Lead.DeclineLead
{
    public class DeclineLeadCommandValidator : AbstractValidator<DeclineLeadCommand>
    {
        public DeclineLeadCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is Required");
        }
    }
}