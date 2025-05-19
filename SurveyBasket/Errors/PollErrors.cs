namespace SurveyBasket.Errors;

public class PollErrors
{
    public static readonly Error PollNotFound =
        new("Poll.NotFound", "No poll was found with the given Id", StatusCodes.Status404NotFound);
    
    public static readonly Error DuplicatedPollTitle =
        new("Poll.DuplicatedPollTitle", "Another poll with the same title is already exists", StatusCodes.Status409Conflict);
}
