﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

using Microsoft.IdentityModel.Tokens;
using System.Xml;

using Microsoft.AspNetCore.Identity;

using Radhey.BAL.Interface.IAccountBAL;
using Radhey.Model;
using Radhey.Model.CommonModel;
using Radhey.Model.RequestModel;


using Radhey.DAL.IdentityTables;

namespace Radhey.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase  
    {

        private readonly IAccountBAL _accountBAL;
        

        public AccountController(IAccountBAL accountBAL)
        {
            this._accountBAL = accountBAL;
        }


        #region User Registration

        #region User Registration Create Async

        [HttpPost]
        [Route("UserRegistrationCreateAsync")]
        public async Task<IActionResult> UserRegistrationCreateAsync(UserRegistrationReqModel userRegistrationReq)
        {
            ResponseComModel apiResponse = new ResponseComModel();
            
            if (userRegistrationReq != null)
            {
                apiResponse = await _accountBAL.UserRegistrationCreateAsync(userRegistrationReq).ConfigureAwait(false);
            
                switch (apiResponse.StatusCode)
                {
                        case 200:   apiResponse = new ResponseComModel()
                        {
                            StatusCode = 200,
                            IsSuccess = true,
                            StatusMessage = "User Registration Successfully"
                        };
                        return Ok(apiResponse);
                        
                        case 400:   apiResponse = new ResponseComModel()
                            {
                            StatusCode = 400,
                            IsSuccess = false,
                            StatusMessage = "User Registration Failed"
                        };
                        return BadRequest(apiResponse);
                    
                        default:   apiResponse = new ResponseComModel()
                        {
                            StatusCode = 500,
                            IsSuccess = false,
                            StatusMessage = "Internal Server Error"
                        };
                        return Ok(apiResponse);       
                }            
            }
            else
            {
                apiResponse = new ResponseComModel()
                {
                    StatusCode = 500,
                    IsSuccess = false,
                    StatusMessage = "Internal Server Error"
                };
                return Ok(apiResponse);
            }
        }

        #endregion

        #region User Registration Create Async With Password

        [HttpPost]
        [Route("UserRegistrationCreateAsyncWithPassword")]
        public async Task<IActionResult> UserRegistrationCreateAsyncWithPassword(UserRegistrationReqModel userRegistrationReq)
        {
            ResponseComModel apiResponse = new ResponseComModel();
            
            if (userRegistrationReq != null)
            {
                apiResponse = await _accountBAL.UserRegistrationCreateAsyncWithPassword(userRegistrationReq).ConfigureAwait(false);
            
                switch (apiResponse.StatusCode)
                {
                        case 200:   apiResponse = new ResponseComModel()
                        {
                            StatusCode = 200,
                            IsSuccess = true,
                            StatusMessage = "User Registration Successfully"
                        };
                        return Ok(apiResponse);
                        
                        case 400:   apiResponse = new ResponseComModel()
                            {
                            StatusCode = 400,
                            IsSuccess = false,
                            StatusMessage = "User Registration Failed"
                        };
                        return BadRequest(apiResponse);
                    
                        default:   apiResponse = new ResponseComModel()
                        {
                            StatusCode = 500,
                            IsSuccess = false,
                            StatusMessage = "Internal Server Error"
                        };
                        return Ok(apiResponse);       
                }            
            }
            else
            {
                apiResponse = new ResponseComModel()
                {
                    StatusCode = 500,
                    IsSuccess = false,
                    StatusMessage = "Internal Server Error"
                };
                return Ok(apiResponse);
            }
        }

        #endregion

        #endregion

       




















    }
}