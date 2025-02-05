using SurveyBasket.IServices;
using SurveyBasket.Models;

namespace SurveyBasket.Services;

public class PollService : IPollService
{
    private static readonly List<Poll> _poll = [
        new Poll
        {
            Id = 1,
            Title = "Poll 1",
            Description = "Description 1"
        },
        
        new Poll
        {
            Id = 2,
            Title = "Poll 2",
            Description = "Description 2"
        },
        
        new Poll
        {
            Id = 3,
            Title = "Poll 3",
            Description = "Description 3"
        },
        ];

    public Poll Add(Poll poll)
    {
        poll.Id = _poll.Count + 1;
        _poll.Add(poll);

        return poll;
    }

    public bool Delete(int Id)
    {
        var Poll = Get(Id);

        if (Poll is null)
            return false;

        _poll.Remove(Poll);

        return true;
    }

    public Poll? Get(int id) => _poll.SingleOrDefault(x => x.Id == id);

    public IEnumerable<Poll> GetAll() => _poll;

    public bool Update(int Id, Poll poll)
    {
        var currentPoll = Get(Id);

        if (currentPoll is null)
            return false;

        currentPoll.Title = poll.Title;
        currentPoll.Description = poll.Description;

        return true;
    }
}
