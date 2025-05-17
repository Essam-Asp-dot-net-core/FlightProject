//using Flight.Repository;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace FlightProject.Controllers.Admin
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AdminAuthController : ControllerBase
//    {
//        private readonly AppDbContext _context;

//        public AdminAuthController(AppDbContext context)
//        {
//            _context = context;
//        }

//        [HttpPost("login")]
//        public async Task<IActionResult> Login([FromBody] LoginDto login)
//        {
//            var user = await _context.AdminUsers
//                .FirstOrDefaultAsync(u => u.Username == login.Username);

//            if (user == null || !user.IsActive)
//                return Unauthorized();

//            bool validPassword = VerifyPassword(login.Password, user.PasswordHash);
//            if (!validPassword)
//                return Unauthorized();

//            var token = GenerateJwtToken(user);

//            return Ok(new { token, role = user.Role });
//        }

//        private bool VerifyPassword(string password, string storedHash)
//        {
//            return BCrypt.Net.BCrypt.Verify(password, storedHash);
//        }

//        private string GenerateJwtToken(AdminUser user)
//        {
//            return "your_jwt_token_here";
//        }
//    }

//}
