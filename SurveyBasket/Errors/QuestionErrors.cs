namespace SurveyBasket.Errors;

public class QuestionErrors
{
    public static readonly Error QuestionNotFound =
        new("Question.NotFound", "No questoin was found with the given Id", StatusCodes.Status404NotFound);

    public static readonly Error DuplicatedQuestionContent =
        new("Question.DuplicatedQuestionContent", "Another question with the same content is already exists", StatusCodes.Status409Conflict);

}
