using EncryptionManager.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EncryptionManager.DataLayer;

internal class ApplicationDbContext : DbContext, IApplicationDbContext
{

}