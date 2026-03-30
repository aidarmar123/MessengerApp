namespace MessengerApi.Application.Messages.Command.SendMessage;

public class SendMessageCommandValidator:AbstractValidator<SendMessageCommand>
{
    public SendMessageCommandValidator()
    {
        RuleFor(x => x.ChatId).NotEmpty();
        RuleFor(x => x.SenderId).NotEmpty();
        RuleFor(x => x.Content)
            .NotEmpty()
            .MaximumLength(2000);
    }
}
