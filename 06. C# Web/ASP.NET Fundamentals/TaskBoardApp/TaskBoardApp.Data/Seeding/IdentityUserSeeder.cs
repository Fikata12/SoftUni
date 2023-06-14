using Microsoft.AspNetCore.Identity;

namespace TaskBoardApp.Data.Seeding
{
	internal class IdentityUserSeeder
	{
		PasswordHasher<IdentityUser> hasher;
		public IdentityUserSeeder()
		{
			hasher = new PasswordHasher<IdentityUser>();
		}

		public IdentityUser GenerateUser()
		{
			var user = new IdentityUser()
			{
				UserName = "test@softuni.bg",
				NormalizedUserName = "test@softuni.bg".ToUpper()
			};
			user.PasswordHash = hasher.HashPassword(user, "softuni");

			return user;
		}
	}
}
