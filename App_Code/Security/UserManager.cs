using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for UserManager
/// </summary>
public class UserManager : UserManager<User>
{
    public UserManager()
        : base(new UserStore<User>(new ApplicationDbContext()))
    {
        this.PasswordHasher = new SQLPasswordHasher();
        this.UserValidator = new UserValidator<User>(this)
        {
            AllowOnlyAlphanumericUserNames = false,
            RequireUniqueEmail = true,

        };

        // Configure validation logic for passwords
        this.PasswordValidator = new PasswordValidator
        {
            RequiredLength = 6,
            RequireNonLetterOrDigit = false,
            RequireDigit = false,
            RequireLowercase = false,
            RequireUppercase = false,

        };
    }
    public static UserManager Create(
       IdentityFactoryOptions<UserManager> options,
       IOwinContext context)
    {
        var manager = new UserManager();

        // Configure validation logic for usernames
        manager.UserValidator = new UserValidator<User>(manager)
        {
            AllowOnlyAlphanumericUserNames = false,
            RequireUniqueEmail = true
        };

        // Configure validation logic for passwords
        manager.PasswordValidator = new PasswordValidator
        {
            RequiredLength = 6,
            RequireNonLetterOrDigit = true,
            RequireDigit = true,
            RequireLowercase = true,
            RequireUppercase = true,
        };
        var dataProtectionProvider = options.DataProtectionProvider;
        if (dataProtectionProvider != null)
        {
            manager.UserTokenProvider =
                new DataProtectorTokenProvider<User>(
                    dataProtectionProvider.Create("ASP.NET Identity"));
        }
        return manager;
    }
}
public class SQLPasswordHasher : PasswordHasher
{
    public override string HashPassword(string password)
    {
        return base.HashPassword(password);
    }

    public override PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
    {
        string[] passwordProperties = hashedPassword.Split('|');
        if (passwordProperties.Length != 3)
        {
            return base.VerifyHashedPassword(hashedPassword, providedPassword);
        }
        else
        {
            string passwordHash = passwordProperties[0];
            int passwordformat = 1;
            string salt = passwordProperties[2];
            if (String.Equals(EncryptPassword(providedPassword, passwordformat, salt), passwordHash, StringComparison.CurrentCultureIgnoreCase))
            {
                return PasswordVerificationResult.SuccessRehashNeeded;
            }
            else
            {
                return PasswordVerificationResult.Failed;
            }
        }
    }

    //This is copied from the existing SQL providers and is provided only for back-compat.
    private string EncryptPassword(string pass, int passwordFormat, string salt)
    {
        if (passwordFormat == 0) // MembershipPasswordFormat.Clear
            return pass;

        byte[] bIn = Encoding.Unicode.GetBytes(pass);
        byte[] bSalt = Convert.FromBase64String(salt);
        byte[] bRet = null;

        if (passwordFormat == 1)
        { // MembershipPasswordFormat.Hashed 
            HashAlgorithm hm = HashAlgorithm.Create("SHA1");
            if (hm is KeyedHashAlgorithm)
            {
                KeyedHashAlgorithm kha = (KeyedHashAlgorithm)hm;
                if (kha.Key.Length == bSalt.Length)
                {
                    kha.Key = bSalt;
                }
                else if (kha.Key.Length < bSalt.Length)
                {
                    byte[] bKey = new byte[kha.Key.Length];
                    Buffer.BlockCopy(bSalt, 0, bKey, 0, bKey.Length);
                    kha.Key = bKey;
                }
                else
                {
                    byte[] bKey = new byte[kha.Key.Length];
                    for (int iter = 0; iter < bKey.Length; )
                    {
                        int len = Math.Min(bSalt.Length, bKey.Length - iter);
                        Buffer.BlockCopy(bSalt, 0, bKey, iter, len);
                        iter += len;
                    }
                    kha.Key = bKey;
                }
                bRet = kha.ComputeHash(bIn);
            }
            else
            {
                byte[] bAll = new byte[bSalt.Length + bIn.Length];
                Buffer.BlockCopy(bSalt, 0, bAll, 0, bSalt.Length);
                Buffer.BlockCopy(bIn, 0, bAll, bSalt.Length, bIn.Length);
                bRet = hm.ComputeHash(bAll);
            }
        }

        return Convert.ToBase64String(bRet);
    }
}