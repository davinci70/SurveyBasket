global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.Extensions.Options;
global using System.Security.Claims;
global using Microsoft.AspNetCore.Identity;
global using SurveyBasket.Abstractions.Consts;

global using Mapster;
global using FluentValidation;

global using SurveyBasket.Entities;
global using SurveyBasket.Services.IService;
global using SurveyBasket.Persistence;
global using SurveyBasket.Contracts.Polls;
global using SurveyBasket.Contracts.Authentication;
global using Microsoft.AspNetCore.Authorization;
global using SurveyBasket.Abstractions;
global using SurveyBasket.Errors;
global using SurveyBasket.Extentions;
global using SurveyBasket.Authentication.Filters;

