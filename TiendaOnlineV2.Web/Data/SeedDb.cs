﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaOnlineV2.Web.Data.Entities;
using TiendaOnlineV2.Web.Enums;
using TiendaOnlineV2.Web.Helpers;
using TiendaOnlineV2.Web.Models;

namespace TiendaOnlineV2.Web.Data
{
    public class SeedDb
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserHelper _userHelper;
        public SeedDb(ApplicationDbContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "Jhon", "Garcia", "jage@yopmail.com", "3000000000", "Calle Luna Calle Sol", UserType.Admin);

        }
        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }
        private async Task<User> CheckUserAsync(
        string document,
        string firstName,
        string lastName,
        string email,
        string phone,
        string address,
        UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    City = _context.Cities.FirstOrDefault(),
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country
                {
                    Name = "Colombia",
                    Departments = new List<Department>
                    {
                        new Department
                        {
                            Name = "Antioquia", Cities = new List<City>
                            {
                                new City
                                {
                                    Name = "Medellín"
                                },
                                new City
                                {
                                    Name = "Envigado"
                                },
                                new City
                                {
                                    Name = "Itagüí"
                                }
                            }
                        },
                        new Department{
                            Name = "Bogotá",
                            Cities = new List<City>
                            {
                                new City
                                {
                                    Name = "Bogotá"
                                }
                            }
                        },
                        new Department
                        {
                            Name = "Valle del Cauca",
                                Cities = new List<City>
                                {
                                    new City{
                                        Name = "Calí"
                                    },
                                    new City{
                                        Name = "Buenaventura"
                                    },
                                    new City {
                                        Name = "Palmira"
                                    }
                                }
                        }
                    }
                });
                _context.Countries.Add(new Country
                {
                    Name = "USA",
                    Departments = new List<Department>
                    {
                        new Department
                        {
                            Name = "California",
                            Cities = new List<City>
                            {
                                new City { Name = "Los Angeles"
                                },
                                new City { Name = "San Diego"
                                },
                                new City { Name = "San Francisco"
                                }
                            }
                        },
                        new Department
                        {
                            Name = "Illinois",
                            Cities = new List<City>
                            {
                                new City
                                {
                                    Name = "Chicago"
                                },
                                new City
                                { Name = "Springfield" }
                            }
                        }
                    }
                });
                await _context.SaveChangesAsync();
            }
        }
    }
}
