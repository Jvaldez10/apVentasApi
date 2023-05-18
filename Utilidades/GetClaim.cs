namespace sistema_venta_erp.Utilidades
{
    public static class GetClaim
    {
        public static string GetClaimValue(HttpContext context, string claimType)
        {
            var claim = context.User.Claims.FirstOrDefault(c => c.Type == claimType);
            return claim?.Value;
        }
    }
}

