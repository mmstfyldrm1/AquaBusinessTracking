using BusinessLayer.Abstract;
using DataAccsessLayer;
using DTOLayer.Dtos.RolePermission;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

public class PermissionManager : IPermissionService
{
    private readonly AquaBusinessTrackingContext _context;

    public PermissionManager(AquaBusinessTrackingContext context)
    {
        _context = context;
    }

    // GET ALL
    public async Task<List<PermissionDto>> GetAll()
    {
        return await _context.Db_Permission
            .Select(x => new PermissionDto
            {
                RecId = x.RecId,
                Module = x.Module,
                Controller = x.Controller,
                Action = x.Action,
                Description = x.Description
            })
            .ToListAsync();
    }

    // GET BY ID
    public async Task<PermissionDto> GetById(int id)
    {
        var x = await _context.Db_Permission.FindAsync(id);

        if (x == null)
            return null;

        return new PermissionDto
        {
            RecId = x.RecId,
            Module = x.Module,
            Controller = x.Controller,
            Action = x.Action,
            Description = x.Description
        };
    }

    // ADD
    public async Task Add(AddPermissionsDto dto)
    {
        var exists = await _context.Db_Permission.AnyAsync(x =>
            x.Module == dto.Module &&
            x.Controller == dto.Controller &&
            x.Action == dto.Action);

        if (exists)
            throw new Exception("Permission already exists");

        var entity = new DB_Permission
        {
            Module = dto.Module,
            Controller = dto.Controller,
            Action = dto.Action,
            Description = dto.Description
        };

        _context.Db_Permission.Add(entity);
        await _context.SaveChangesAsync();
    }

    // UPDATE
    public async Task Update(UpdatePermissionsDto dto)
    {
        var entity = await _context.Db_Permission.FindAsync(dto.RecId);

        if (entity == null)
            throw new Exception("Permission not found");

        entity.Module = dto.Module;
        entity.Controller = dto.Controller;
        entity.Action = dto.Action;
        entity.Description = dto.Description;

        await _context.SaveChangesAsync();
    }

    // DELETE
    public async Task Delete(int id)
    {
        var entity = await _context.Db_Permission.FindAsync(id);

        if (entity == null)
            return;

        _context.Db_Permission.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<PermissionDto>> GetByName()
    {
        return await _context.Db_Permission
            .Select(x => new PermissionDto
            {
                RecId = x.RecId,
                Module = x.Module,
                Controller = x.Controller,
                Action = x.Action,
                Description = x.Description
            })
            .ToListAsync();
    }
}