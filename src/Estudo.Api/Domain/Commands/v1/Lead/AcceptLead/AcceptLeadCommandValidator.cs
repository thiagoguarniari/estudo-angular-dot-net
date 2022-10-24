using FluentValidation;

namespace Domain.Commands.v1.Lead.AcceptLead
{
    public class AcceptLeadCommandValidator : AbstractValidator<AcceptLeadCommand>
    {
        public AcceptLeadCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is Required");
        }
    }
}