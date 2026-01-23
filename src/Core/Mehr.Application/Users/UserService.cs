using Mehr.Application.Users.Contracts;
using Mehr.Application.Users.Contracts.Exceptions;
using Mehr.Domain.Users;
using Mehr.Domain.Users.Contracts;
using Mehr.Domain.Users.Contracts.Dtos;
using Mehr.SharedKernel;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using Mehr.Application.ApiValidate.Contracts;
using Mehr.Application.ApiValidate.Contracts.Exceptions;

namespace Mehr.Application.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IApiValidateService _apiValidateService;
    private readonly IUserContext _userContext;

    public UserService(IUserRepository repository,
        IRoleRepository roleRepository,
        IUnitOfWork unitOfWork,
        IApiValidateService apiValidateService,
        IUserContext userContext)
    {
        _repository = repository;
        _roleRepository = roleRepository;
        _unitOfWork = unitOfWork;
        _apiValidateService = apiValidateService;
        _userContext = userContext;
    }

    public async Task<Result<GetUserDto>> GetUserById(int id, CancellationToken cancellation)
    {
        var user = await _repository.GetUserByIdAsync(id, cancellation);

        if (user is null)
            return Result.Failure<GetUserDto>(UserErrors.NotFound(id));

        return new GetUserDto
        {
            Id = user.Id,
            UserName = user.UserName,
            IsDisable = user.IsDisable,
            RoleId = user.RoleId,
            SecureLevel = user.SecureLevelId
        };
    }

    public async Task<Result<string>> UserLoginAsync(UserLoginDto dto, CancellationToken cancellationToken)
    {
        var user = await _repository.GetUserByUsernameAsync(dto.Username, cancellationToken);

        if (user is null)
            return Result.Failure<string>(UserErrors.NotValid());

        if (user.IsDisable)
            return Result.Failure<string>(UserErrors.IsSuspend(dto.Username));

        if (!CheckPassword(dto.Password, user.Password))
            return Result.Failure<string>(UserErrors.NotValid());

        //var resValidateService = await _apiValidateService.IsValidate(dto, cancellationToken);
        var resValidateService = Result.Success<DateTime>(DateTime.Now.AddDays(250));

        if (!resValidateService.IsSuccess)
            return Result.Failure<string>(resValidateService.Error);

        var policies = await _roleRepository.GetPolicyList(user.RoleId, cancellationToken);

        var token = CreateToken(user, (DateTime)resValidateService.Value, policies);
        return token;
    }

    private bool CheckPassword(string password, string hashPassword)
    {

        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        var NewPassWordHash = md5.ComputeHash(Encoding.ASCII.GetBytes($"ab32asd{password}a876qefg"));
        string paswwordH = Encoding.ASCII.GetString(NewPassWordHash);
        if (paswwordH != hashPassword)
        {
            return false;
        }
        return true;

    }
    private string CreateToken(User user, DateTime validDate, List<RolePolicy_QueryModel> policies)
    {
        var policyArr = policies.Where(x=> x.Value == 1)
            .Select(x => x.Id).ToArray();
        var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("c0d0cd85-f64e-4fcd-8625-c8c37c5bdd85"));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claimsForToken = new List<Claim>();
        claimsForToken.Add(new Claim("userId", user.Id.ToString()));
        claimsForToken.Add(new Claim("UserName", user.UserName.ToString()));
        claimsForToken.Add(new Claim("GroupId", user.RoleId.ToString()));
        claimsForToken.Add(new Claim("SecureLevel", user.SecureLevelId.ToString()));
        foreach (var item in policyArr)
        {
            claimsForToken.Add(new Claim(CustomClaimTypes.Permission, item.ToString()));
        }
        var jwtSecurityToke = new JwtSecurityToken(
            "Jwt:Issuer",
            "Jwt:Audience",
            claimsForToken,
            DateTime.Now,
            validDate,
            signingCredentials
            );

        var tokenToReturn = new JwtSecurityTokenHandler()
            .WriteToken(jwtSecurityToke);
        return tokenToReturn;
    }

    
}

public enum MehrPolicy
{
    Documnet = 100,
    Documnet_Add = 200,
    Document_AddTemp = 250,
    Documnet_RowEdit = 300,
    Documnet_Delete = 400,
    DocUment_OpeningBalance = 430,
    Documnet_Combine = 450,
    Document_HeadEdit = 500,
    document_SimpleRowEdit = 600,
    Document_IgnorCredit = 700,
    Document_AddOutOfDate = 701,
    Document_EditLimited = 702,

    Account_Person = 900,
    Account_Person_Main = 990,
    Account_Person_Add = 1000,
    Account_Person_Edit = 1100,
    Account_Person_Credit = 1110,
    Account_Customer = 1120,
    Account_Customer_Add = 1130,
    Account_Customer_Edit = 1140,
    Account_DecreaseAndIncreaseCredit = 1150,

    Account_Cost = 1200,
    Account_Cost_Add_Edit = 1300,

    Account_Bank = 1400,
    Account_Bank_Add_Edit = 1500,

    Account_CheckIn = 1600,
    Account_CheckOut = 1700,
    Account_Cash = 1800,
    Account_Cash_MultiCash = 1900,
    Account_Cash_ShowCashRemain = 1910,

    Account_GhestIn = 2000,
    Account_Factors = 2100,
    Account_Motefarreghe = 2200,
    Account_Motefarreghe_Add_Edit = 2250,

    Anbar_Good_Add = 2400,
    Anbar_Good_Edit = 2500,
    Anbar_Good_ShowInfo = 2600,
    Anbar_Good_GoodCard = 2601,
    Anbar_Good_BuyPrice = 2650,
    Anbar_Good_InvoiceBenefit = 2651,
    Anbar_Ignor_Availability = 2700,
    Anbar_Access_DiscountPer1 = 2710,
    Anbar_Access_DiscountPer2 = 2720,
    Anbar_Access_DiscountFee = 2730,
    Anbar_Access_ChangePrice = 2740,
    Anbar_Access_BenefitAndCost = 200000,
    Anbar_Access_LimitBetweenSalePrice4And5 = 2760,
    Anbar_SellUnderAndAbovePrice = 2800,
    Anbar_Access_SalePrices = 2810,
    Anbar_Access_SalePrice1 = 2811,
    Anbar_Access_SalePrice2 = 2812,
    Anbar_Access_SalePrice3 = 2813,
    Anbar_Access_SalePrice4 = 2814,
    Anbar_Access_SalePrice5 = 2815,


    InvoiceRowEdit = 5750,
    Invoice_Buy = 3400,
    Invoice_Buy_Add = 3500,
    Invoice_Buy_Edit = 3600,
    Invoice_Buy_Delete = 3700,
    Invoice_Buy_AddOutOfDate = 3701,
    Invoice_Buy_EditLimited = 3702,

    Invoice_Sell = 3800,
    Invoice_Sell_Add = 3900,
    Invoice_Sell_Edit = 4000,
    Invoice_Sell_Delete = 4100,
    Invoice_Sell_AddOutOfDate = 4101,
    Invoice_Sell_EditLimited = 4102,

    Invoice_FromBuy = 4600,
    Invoice_FromBuy_Add = 4700,
    Invoice_FromBuy_Edit = 4800,
    Invoice_FromBuy_Delete = 4900,
    Invoice_FromBuy_AddOutOfDate = 4901,
    Invoice_FromBuy_EditLimited = 4902,

    Invoice_FromSell = 4200,
    Invoice_FromSell_Add = 4300,
    Invoice_FromSell_Edit = 4400,
    Invoice_FromSell_Delete = 4500,
    Invoice_FromSell_AddOutOfDate = 4501,
    Invoice_FromSell_EditLimited = 4502,

    Invoice_TransferOut = 4620,
    Invoice_TransferOut_Add = 7300,
    Invoice_TransferOut_Edit = 7400,
    Invoice_TransferOut_Delete = 7500,
    Invoice_TransferOut_AddOutOfDate = 7501,
    Invoice_TransferOut_EditLimited = 7502,

    Invoice_TransferIn = 4640,
    Invoice_TransferIn_Add = 7600,
    Invoice_TransferIn_Edit = 7700,
    Invoice_TransferIn_Delete = 7800,
    Invoice_TransferIn_AddOutOfDate = 7801,
    Invoice_TransferIn_EditLimited = 7802,

    Invoice_Amani = 5400,
    Invoice_Amani_Add = 5500,
    Invoice_Amani_Edit = 5600,
    Invoice_Amani_Delete = 5700,
    Invoice_Amani_AddOutOfDate = 5701,
    Invoice_Amani_EditLimited = 5702,

    Invoice_Movaghat = 5000,
    Invoice_Movaghat_Add = 5100,
    Invoice_Movaghat_Edit = 5200,
    Invoice_Movaghat_Delete = 5300,
    Invoice_Movaghat_AddOutOfDate = 5301,
    Invoice_Movaghat_EditLimited = 5302,

    StockChecking = 8000,
    StockChecking_Add = 8100,
    StockChecking_AddTemp = 8150,
    StockChecking_Edit = 8200,
    StockChecking_Delete = 8300,

    TransferWareHouse = 8400,
    TransferWareHouse_Add = 8500,
    TransferWareHouse_Edit = 8600,
    TransferWareHouse_Delete = 8700,
    TransferWareHouse_Movaghat = 8710,

    DistributionList = 8800,
    DistributionList_Add = 8810,
    DistributionList_Edit = 8820,
    DistributionList_Delete = 8830,

    Inventory_TransferIn = 9300,
    Inventory_TransferIn_Add = 9301,
    Inventory_TransferIn_AddTemp = 9302,
    Inventory_TransferIn_Edit = 9303,
    Inventory_TransferIn_Delete = 9304,

    Inventory_TransferOut = 9400,
    Inventory_TransferOut_Add = 9401,
    Inventory_TransferOut_AddTemp = 9402,
    Inventory_TransferOut_Edit = 9403,
    Inventory_TransferOut_Delete = 9404,
    Inventory_TransferOut_JustImportByDocDetail = 9405,
    Inventory_TransferOut_InsertAuto = 9406,

    Target = 9410,
    Target_Add = 9411,
    Target_Edit = 9412,
    Target_Delete = 9413,

    Movadian = 9420,
    Movadian_Setting = 9421,
    Movadian_InvoiceList = 9422,

    Pricing = 9500,
    Pricing_Add = 9501,
    Pricing_Edit = 9502,
    Pricing_Delete = 9503,

    eShop = 9511,
    eShop_Setting = 9512,
    eShop_NewUserList = 9513,
    eShop_NewInvoiceList = 9514,
    eShop_PersonList = 9515,
    eShop_InvoiceList = 9516,
    eShop_LogList = 9517,
    eShop_SyncList = 9518,
    eShop_LogSyncedList = 9519,


    ManagerDashboard = 9600,

    ManagerDashboard_Design = 9601,
    ManagerDashboard_Design_Create = 9602,
    ManagerDashboard_Design_Edit = 9603,
    ManagerDashboard_Design_Delete = 9604,

    ManagerDashboard_Chart = 9610,
    ManagerDashboard_Chart_Cost = 9611,
    ManagerDashboard_Chart_CashAndBank = 9612,
    ManagerDashboard_Chart_Sales = 9613,
    ManagerDashboard_Chart_Checks = 9614,
    ManagerDashboard_Chart_Benefit = 9615,
    ManagerDashboard_Chart_Visitors = 9616,
    ManagerDashboard_Chart_Goods = 9617,
    ManagerDashboard_Chart_Person = 9618,
    ManagerDashboard_Chart_Zone = 9619,

    ManagerDashboard_MainPage = 9650,
    ManagerDashboard_MainPage_StockRemain = 9651,
    ManagerDashboard_MainPage_SalseCurrentMonth = 9652,
    ManagerDashboard_MainPage_CostCurrentMonth = 9653,
    ManagerDashboard_MainPage_CreditPerson = 9654,
    ManagerDashboard_MainPage_DebtorPerson = 9655,
    ManagerDashboard_MainPage_BanksRemain = 9656,
    ManagerDashboard_MainPage_SalesChart = 9657,
    ManagerDashboard_MainPage_SalesReturnChart = 9658,
    ManagerDashboard_MainPage_VisitorList = 9659,

    ManagerDashboard_DesignedAccess = 9700,

    Automation_Scadule = 9000,
    Scadule_All = 9100,

    Setting_Users = 6800,

    LayOuts_Select = 5900,
    LayOuts_Print_Select = 6000,
    LayOut_Print = 6200,
    LayOuts_Export = 6300,

    Program_Backup = 6600,


    GridLists = 100000,
    LayoutsLists = 20000,
    PrintLayoutsLists = 24000,
    WareHouses = 30000,

    //For admin only
    Admin_InvoiceDaramad = -1,

    //always tru
    Account_ShowInfo = 0,

    //others
    //EnteghalDoreh = 1.1,
}
public static class CustomClaimTypes
{
    public const string Permission = "mp.";
}