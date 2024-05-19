﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SonmezERP.Dtos;
using SonmezERP.Models;
using SonmezERP.ViewModels;

namespace SonmezERP.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;
        public UserController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _userManager.Users.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(
                new UserDtoForCreation()
                {
                    Roles = new HashSet<string>(_roleManager.Roles.Select(r => r.Name).ToList()!)
                }
                );
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserDtoForCreation userDto)
        {
            var user = new AppUser()
            {
                Name=userDto.Name,
                Surname = userDto.Surname,
                UserName = userDto.UserName,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user,userDto.Password!);
            if (!result.Succeeded)
            {
                throw new Exception("Kullanıcı Oluşturulamadı.");
            }
            if (userDto.Roles.Count>0)
            {
                var roleResult = await _userManager.AddToRolesAsync(user, userDto.Roles);
                if (!roleResult.Succeeded)
                {
                    throw new Exception("Sistemin Rollerle İlgili sorunları var!!");
                }
            }
            return result.Succeeded
                ? RedirectToAction("Index")
                : View();
        }
       
        
        [HttpGet]
        public async Task<IActionResult> Update([FromRoute(Name ="id")] string id)
        {
            var user = await GetOneUser(id);
            var userDto = _mapper.Map<UserDtoForUpdate>(user);
            userDto.Roles = new HashSet<string>(await _userManager.GetRolesAsync(user));

            return View(userDto);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] UserDtoForUpdate userDto)
        {
            if (ModelState.IsValid)
            {
                var user = await GetOneUser(userDto.UserName);

                user.Name = userDto.Name;
                user.Surname = userDto.Surname;
                user.PhoneNumber = userDto.PhoneNumber;
                user.Email = userDto.Email;
                if (user is not null)
                {
                    var result = await _userManager.UpdateAsync(user);
                    if (userDto.Roles.Count > 0)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);
                        var r1 = await _userManager.RemoveFromRolesAsync(user, userRoles);
                        var r2 = await _userManager.AddToRolesAsync(user, userDto.Roles);
                    }
                }
                else
                {

                throw new Exception("System has problem with user update");
                }
                return RedirectToAction("Index");
            }
            return View();
        }
        //User okuma Action
        public async Task<AppUser> GetOneUser(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }
        //User gücelleme Action
        //public async Task Update(UserDtoForUpdate userDto)
        //{
            
            
        //}
        public async Task<UserDtoForUpdate> GetOneUserForUpdate(string userName)
        {
            var user = await GetOneUser(userName);
            if (user is not null)
            {
                var userDto = _mapper.Map<UserDtoForUpdate>(user);

                userDto.Roles = new HashSet<string>(_roleManager.Roles.Select(r => r.Name).ToList());
                userDto.UserRoles = new HashSet<string>(await _userManager.GetRolesAsync(user));
                return userDto;
            }
            throw new Exception("An error occured.");
        }

    }
}
