namespace Microsoft.Extensions.DependencyInjection.Users.Command.CreateUser;

public class CreatUserCommandValidator:AbstractValidator<CreatUserCommand>
{
    public CreatUserCommandValidator()
    {
        RuleFor(x=>x.alice).NotEmpty();
        RuleFor(x=>x.firstName).NotEmpty();
    }
}
