using MasterPol.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace MasterPol.Repositories;

public class PartnerTypeRepository(DbContext context):Repository<PartnerType>(context);