namespace SurveyBasket.Contracts.Results;

public record VotesPerDayResponse(
    DateOnly date,
    int NumberOfVotes
);
