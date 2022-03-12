using System;
using System.Linq;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // MembershipTypes
                if (context.MembershipTypes.Any())
                {
                    Console.WriteLine("MembershipTypes already seeded!");
                }
                else
                {
                    context.MembershipTypes.AddRange(
                    new MembershipType
                    {
                        Id = 1,
                        Name = "Pay as You Go",
                        SignUpFee = 0,
                        DurationInMonths = 0,
                        DiscountRate = 0
                    },
                    new MembershipType
                    {
                        Id = 2,
                        Name = "Monthly",
                        SignUpFee = 30,
                        DurationInMonths = 1,
                        DiscountRate = 10
                    },
                    new MembershipType
                    {
                        Id = 3,
                        Name = "Quaterly",
                        SignUpFee = 90,
                        DurationInMonths = 3,
                        DiscountRate = 15
                    },
                    new MembershipType
                    {
                        Id = 4,
                        Name = "Yearly",
                        SignUpFee = 300,
                        DurationInMonths = 12,
                        DiscountRate = 20
                    });
                }

                // Genres
                if (context.Genre.Any())
                {
                    Console.WriteLine("Genres already seeded!");
                }
                else
                {
                    context.Genre.AddRange(
                        new Genre
                        {
                            Id = 1,
                            Name = "Non-fiction",
                        },
                        new Genre
                        {
                            Id = 2,
                            Name = "Fantasy"
                        });
                }

                // Customers
                if (context.Customers.Any())
                {
                    Console.WriteLine("Customers already seeded!");
                }
                else
                {
                    context.Customers.AddRange(
                        new Customer
                        {
                            Name = "Robert Gierczak",
                            Birthdate = new DateTime(1991, 6, 22),
                            HasNewsletterSubscribed = true,
                            MembershipTypeId = 1
                        },
                        new Customer
                        {
                            Name = "Andrzej Dukat",
                            Birthdate = new DateTime(1992, 5, 11),
                            HasNewsletterSubscribed = true,
                            MembershipTypeId = 1
                        },
                        new Customer
                        {
                            Name = "Radosław Traczyński",
                            Birthdate = new DateTime(1993, 4, 10),
                            HasNewsletterSubscribed = false,
                            MembershipTypeId = 1,
                        });
                }

                // Books
                if (context.Books.Any())
                {
                    Console.WriteLine("Books already seeded!");
                }
                else
                {
                    context.Books.AddRange(
                        new Book
                        {
                            ReleaseDate = new DateTime(1990, 1, 2),
                            AuthorName = "Margaret Mitchel",
                            GenreId = 1,
                            Name = "Przeminęło z Wiatrem",
                            NumberInStock = 25,
                        },
                        new Book
                        {
                            ReleaseDate = new DateTime(1984, 4, 1),
                            AuthorName = "Dan Brown",
                            GenreId = 2,
                            Name = "Kod Leonarda da Vinci",
                            NumberInStock = 69,
                        },
                        new Book
                        {
                            ReleaseDate = new DateTime(2014, 9, 20),
                            AuthorName = "J.K. Rowling",
                            GenreId = 1,
                            Name = "Harry Potter",
                            NumberInStock = 6,
                        });
                }

                context.SaveChanges();
            }
        }
    }
}