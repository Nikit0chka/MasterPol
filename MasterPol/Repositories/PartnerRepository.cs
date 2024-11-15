using MasterPol.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace MasterPol.Repositories;

internal class PartnerRepository(DbContext context):Repository<Partner>(context);