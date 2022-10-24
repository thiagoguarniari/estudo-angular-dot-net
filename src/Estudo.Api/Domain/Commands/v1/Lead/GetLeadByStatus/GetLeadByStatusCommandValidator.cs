using FluentValidation;

namespace Domain.Commands.v1.Lead.GetLeadByStatus
{
    public class GetLeadByStatusCommandValidator : AbstractValidator<GetLeadByStatusCommand>
    {
        public GetLeadByStatusCommandValidator()
        {
            RuleFor(x => x.Status)
                .NotEmpty()
                .NotNull()
                .WithMessage("Status is Required");
        }
    }
}