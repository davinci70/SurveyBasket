﻿using SurveyBasket.Contracts.Responses;

namespace SurveyBasket.Contracts.Requests;

public record CreatePollRequest(string Title, string Description);
