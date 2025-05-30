

namespace AutoLandProcessor.Models
{
    public static class UserExtentions
    {
		public static User Clone(this User source)
		{
			return new User
			{
				Id			= source.Id,
				Login		= source.Login,
				Role		= source.Role,
				Password	= source.Password,
				Name		= source.Name,
				Surname		= source.Surname,
				Birthday	= source.Birthday,
				Email		= source.Email,
				Telephone	= source.Telephone,
				Address		= source.Address,
				Avatar		= source.Avatar
			};
		}

		public static void CopyFrom(this User target, User source)
		{
			target.Id		= source.Id;
			target.Login	= source.Login;
			target.Role		= source.Role;
			target.Password = source.Password;
			target.Name		= source.Name;
			target.Surname	= source.Surname;
			target.Birthday = source.Birthday;
			target.Email	= source.Email;
			target.Telephone = source.Telephone;
			target.Address	= source.Address;
			target.Avatar	= source.Avatar;
		}
	}
}
