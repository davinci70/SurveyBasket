namespace SurveyBasket.Errors;

public static class VoteErrors
{
    public static readonly Error DublicatedVote =
        new("Vote.DublicatedVote", "This user has already voted for this poll", StatusCodes.Status409Conflict);

    public static readonly Error InvalidQuestions =
        new Error("Vote.InvalidQuestions", "Invalid questions", StatusCodes.Status400BadRequest);
}
