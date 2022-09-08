﻿using FluentValidation.Results;

namespace Api.Service.Services
{
    public class ResultService
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public ICollection<ValidateError> Errors { get; set; }

        public static ResultService RequestError(string message, ValidationResult validationResult)
            => new ResultService
            {
                Success = false,
                Message = message,
                Errors = validationResult.Errors.Select(x => new ValidateError { Field = x.PropertyName, Message = x.ErrorMessage }).ToList()
            };

        public static ResultService<T> RequestError<T>(string message, ValidationResult validationResult)
            => new ResultService<T>
            {
                Success = false,
                Message = message,
                Errors = validationResult.Errors.Select(x => new ValidateError { Field = x.PropertyName, Message = x.ErrorMessage }).ToList()
            };

        public static ResultService Fail(string message)
            => new ResultService
            {
                Success = false,
                Message = message
            };

        public static ResultService<T> Fail<T>(string message)
            => new ResultService<T>
            {
                Success = false,
                Message = message
            };

        public static ResultService Ok(string message)
            => new ResultService
            {
                Success = true,
                Message = message
            };


        public static ResultService<T> Ok<T>(T data)
            => new ResultService<T>
            {
                Success = true,
                Data = data
            };
    }

    public class ResultService<T> : ResultService
    {
        public T Data { get; set; }
    }
}
