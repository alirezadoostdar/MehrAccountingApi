using Mehr.Domain.Entities.Accounts;
using Mehr.Domain.Entities.Banks;

namespace Mehr.Domain.Entities.Checks;

public class Check_Received : DetailedAccount
{
    public long SerialNumber { get; set; }
    public string Comment { get; set; }
    public string AccouuntNumber { get; set; }
    public string ShamsiDate { get; set; }
    public string BankName { get; set; }
    public int DocItemId { get; set; }
    public int BankId { get; set; }
    public Bank Bank { get; set; }
    public int PersonId { get; set; }
    public DetailedAccount Person { get; set; }
    public string DepositShamsiDate { get; set; }
    public bool SmsSent { get; set; }
    public bool IsReject { get; set; }
    public DateTime Date { get; set; }
    public DateTime DepositDate { get; set; }
    public string SayadiCode { get; set; }
    public bool IsTransferred { get; set; }
    public SayadiStatus SayadiStatus { get; set; }
    public string RejectShamsiDate { get; set; }
    public DateTime RejectDate { get; set; }
    public string PassShamsiDate { get; set; }
    public DateTime PassDate { get; set; }
    public int LastDocId { get; set; }

    public CheckRecivedStatus Status { get; set; }
    public int DepositDocId { get; set; }
}

public enum SayadiStatus
{
    White = 1,
    Yellow = 2,
    Orange = 3,
    Brown = 4,
    Red = 5
}

public enum CheckRecivedStatus
{
    Receved = 1,
    ThirdParty = 2,
    Deposit = 3,
    Pass = 4,
    NotPass = 5,
    ReturnFromThirdParty = 6,
    Return = 7,
    Delete =8
}