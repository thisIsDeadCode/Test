﻿using Test.Api.Data.Models;
using Test.Api.View.Models.Requests;
using Test.Api.View.Models.Responses;

namespace Test.Api.View.Extensions
{
    public static class Converters
    {
        public static AdvertisementResponse ToAdvertisementResponse(this Advertisement advertisement)
        {
            return new AdvertisementResponse()
            {
                Id = advertisement.Id,
                AuthorId = advertisement.AuthorId,
                Author = $"{advertisement.Author?.Name} {advertisement.Author?.Surname}",
                Title = advertisement.Title,
                Content = advertisement.Content,
                CreatedDate = advertisement.CreatedDate,
                ModifiedDate = advertisement.ModifiedDate,
                StartDate = advertisement.StartDate,
                FinishedDate = advertisement.FinishedDate,
            };
        }

        public static List<AdvertisementResponse> ToAdvertisementResponse(this IEnumerable<Advertisement> advertisements)
        {
            var list = new List<AdvertisementResponse>();
            foreach(var advertisement in advertisements)
            {
                list.Add(new AdvertisementResponse()
                {
                    Id = advertisement.Id,
                    AuthorId = advertisement.AuthorId,
                    Author = $"{advertisement.Author?.Name} {advertisement.Author?.Surname}",
                    Title = advertisement.Title,
                    Content = advertisement.Content,
                    CreatedDate = advertisement.CreatedDate,
                    ModifiedDate = advertisement.ModifiedDate,
                    StartDate = advertisement.StartDate,
                    FinishedDate = advertisement.FinishedDate,
                });
            }
            return list;
        }

        public static AuthorResponse ToAuthorReponse(this Author author)
        {
            return new AuthorResponse()
            {
                Id = author.Id,
                Name = author.Name,
                Rating = author.Rating,
                Surname = author.Surname,
            };
        }

        public static List<AuthorResponse> ToAuthorReponse(this IEnumerable<Author> authors)
        {
            var list = new List<AuthorResponse>();
            foreach (var author in authors)
            {
                list.Add(new AuthorResponse()
                {
                    Id = author.Id,
                    Name = author.Name,
                    Rating = author.Rating,
                    Surname = author.Surname,
                });
            }
            return list;
        }

        public static Advertisement ToAdvertisementModel(this AdvertisementRequest advertisement)
        {
            return new Advertisement()
            {
                Id = advertisement.Id,
                Title = advertisement.Title,
                Content = advertisement.Content,
                CreatedDate = advertisement.CreatedDate,
                ModifiedDate = advertisement.ModifiedDate,
                StartDate = advertisement.StartDate,
                FinishedDate = advertisement.FinishedDate,
                AuthorId= advertisement.AuthorId,
            };
        }

        public static List<Advertisement> ToAdvertisementModel(this IEnumerable<AdvertisementRequest> advertisements)
        {
            var list = new List<Advertisement>();
            foreach (var advertisement in advertisements)
            {
                list.Add(new Advertisement()
                {
                    Id = advertisement.Id,
                    Title = advertisement.Title,
                    Content = advertisement.Content,
                    CreatedDate = advertisement.CreatedDate,
                    ModifiedDate = advertisement.ModifiedDate,
                    StartDate = advertisement.StartDate,
                    FinishedDate = advertisement.FinishedDate,
                    AuthorId = advertisement.AuthorId,
                });
            }
            return list;
        }

        public static Author ToAuthorModel(this AuthorRequest author)
        {
            return new Author()
            {
                Id = author.Id,
                Name = author.Name,
                Rating = author.Rating,
                Surname = author.Surname,
            };
        }

        public static List<Author> ToAuthorModel(this IEnumerable<AuthorRequest> authors)
        {
            var list = new List<Author>();
            foreach (var author in authors)
            {
                list.Add(new Author()
                {
                    Id = author.Id,
                    Name = author.Name,
                    Rating = author.Rating,
                    Surname = author.Surname,
                });
            }
            return list;
        }
    }
}
