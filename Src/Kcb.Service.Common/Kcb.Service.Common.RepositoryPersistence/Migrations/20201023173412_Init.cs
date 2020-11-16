using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kcb.Service.Common.RepositoryPersistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(nullable: true),
                    RoleDescription = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserPasswords",
                columns: table => new
                {
                    UserPasswordId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    UserPasswordSalt = table.Column<Guid>(nullable: false),
                    UserPasswordHash = table.Column<byte[]>(nullable: true),
                    CreatedBy = table.Column<long>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPasswords", x => x.UserPasswordId);
                    table.ForeignKey(
                        name: "FK_UserPasswords_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserRoleId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserRoleId);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPasswords_UserId",
                table: "UserPasswords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            var sqlGetUserValidation = @"
            IF OBJECT_ID('GetUserValidation', 'P') IS NOT NULL
            DROP PROCEDURE GetUserValidation
            GO
 
            CREATE PROCEDURE dbo.GetUserValidation @userName VARCHAR(100)
	            ,@password VARCHAR(100)
            AS
            BEGIN
	            SET NOCOUNT ON;

	            SELECT TOP 1 u.[UserId]
		            ,u.[FirstName]
		            ,u.[MiddleName]
		            ,u.[LastName]
		            ,u.[UserName]
		            ,u.[EmailAddress]
		            ,u.[PhoneNo]
		            ,u.[IsActive]
                    ,u.CreatedBy
		            ,u.CreatedDate
		            ,u.ModifiedBy
		            ,u.ModifiedDate
	            FROM dbo.UserPassword up
	            INNER JOIN dbo.[User] u ON up.UserId = u.UserId
	            WHERE u.UserName = @userName
		            AND UserPasswordHash = HASHBYTES('SHA2_512', @password + CAST(UserPasswordSalt AS NVARCHAR(36)))
            END";

            migrationBuilder.Sql(sqlGetUserValidation);


            var sqlInsertUserwithPassword = @"
            IF OBJECT_ID('InsertUserwithPassword', 'P') IS NOT NULL
            DROP PROCEDURE InsertUserwithPassword
            GO
 
            CREATE PROCEDURE dbo.InsertUserwithPassword @firstName VARCHAR(100)
	            ,@lastName VARCHAR(100)
	            ,@userName VARCHAR(100)
	            ,@emailAddress VARCHAR(100)
	            ,@password VARCHAR(100)	
            AS
            BEGIN
	            -- SET NOCOUNT ON added to prevent extra result sets from
	            -- interfering with SELECT statements.
	            SET NOCOUNT ON;

	            DECLARE @responseMessage NVARCHAR(250)
	            DECLARE @salt UNIQUEIDENTIFIER = NEWID()

	            BEGIN TRY
		            INSERT INTO dbo.[User] (
			            FirstName
			            ,LastName
			            ,UserName
			            ,EmailAddress
			            )
		            VALUES (
			            @firstName
			            ,@lastName
			            ,@userName
			            ,@emailAddress
			            )

		            INSERT INTO [dbo].[UserPassword] (
			            UserId
			            ,UserPasswordSalt
			            ,UserPasswordHash
			            )
		            VALUES (
			            SCOPE_IDENTITY()
			            ,@salt
			            ,HASHBYTES('SHA2_512', @password + CAST(@salt AS NVARCHAR(36)))
			            )

		            SET @responseMessage = 'Success'

		            SELECT @responseMessage AS [Message]
	            END TRY

	            BEGIN CATCH
		            SET @responseMessage = ERROR_MESSAGE()

		            SELECT @responseMessage AS [Message]
	            END CATCH
            END";

            migrationBuilder.Sql(sqlInsertUserwithPassword);


            var InsertOrUpdateUserwithPassword = @"
            IF OBJECT_ID('InsertOrUpdateUserwithPassword', 'P') IS NOT NULL
            DROP PROCEDURE InsertOrUpdateUserwithPassword
            GO
 
            CREATE PROCEDURE [dbo].[InsertOrUpdateUserwithPassword]
				 @userId BIGINT = 0
				,@firstName VARCHAR(100)
				,@middleName VARCHAR(100) = NULL
				,@lastName VARCHAR(100)
				,@userName VARCHAR(100)
				,@emailAddress VARCHAR(100)
				,@phoneNo VARCHAR(20) = NULL
				,@isActive BIT = 1
				,@password VARCHAR(100)	= NULL
				,@loginUserId BIGINT = -1
			AS
			BEGIN
				-- SET NOCOUNT ON added to prevent extra result sets from
				-- interfering with SELECT statements.
				SET NOCOUNT ON;

				IF EXISTS(SELECT TOP 1 1 FROM dbo.[User] WHERE UserName = @userName)
				BEGIN
				   RAISERROR('UserName already exists', 16, 1)
				   RETURN;
				END

				IF EXISTS(SELECT TOP 1 1 FROM dbo.[User] WHERE EmailAddress = @emailAddress)
				BEGIN
				   RAISERROR('EmailAddress already exists', 16, 1)
				   RETURN;
				END

				DECLARE @responseMessage NVARCHAR(250)
				DECLARE @salt UNIQUEIDENTIFIER = NEWID()

				BEGIN TRY

					IF @userId = 0
					BEGIN

					INSERT INTO dbo.[User] (
						FirstName
						,MiddleName
						,LastName
						,UserName
						,EmailAddress
						,PhoneNo
						,IsActive
						,CreatedBy
						,CreatedDate
						,ModifiedBy
						,ModifiedDate
						)
					VALUES (
						@firstName
						,@middleName
						,@lastName
						,@userName
						,@emailAddress
						,@phoneNo
						,@isActive
						,@loginUserId
						,GETDATE()
						,@loginUserId
						,GETDATE()
						)

					INSERT INTO [dbo].[UserPassword] (
						UserId
						,UserPasswordSalt
						,UserPasswordHash
						,CreatedBy
						,CreatedDate
						,ModifiedBy
						,ModifiedDate
						)
					VALUES (
						SCOPE_IDENTITY()
						,@salt
						,HASHBYTES('SHA2_512', @password + CAST(@salt AS VARCHAR(36)))
						,@loginUserId
						,GETDATE()
						,@loginUserId
						,GETDATE()
						)

					END
					ELSE
					BEGIN
						UPDATE [dbo].[User]
						SET [FirstName] = @firstName
							,[MiddleName] = @middleName
							,[LastName] = @lastName
							,[UserName] = @userName
							,[EmailAddress] = @emailAddress
							,[PhoneNo] = @phoneNo
							,[IsActive] = @isActive
							,[ModifiedBy] = @loginUserId
							,[ModifiedDate] = GETDATE()
						WHERE UserId = @userId

						IF (ISNULL(@password,'') <> '')
						BEGIN
				
							UPDATE [dbo].[UserPassword]
							SET  [UserPasswordSalt] = @salt
								,UserPasswordHash = HASHBYTES('SHA2_512', @password + CAST(@salt AS VARCHAR(36)))			
								,[ModifiedBy] = @loginUserId
								,[ModifiedDate] = GETDATE()
							WHERE UserId = @userId
						END

					END

					SET @responseMessage = 'Success'

					SELECT @responseMessage AS [Message]
				END TRY

				BEGIN CATCH
					SET @responseMessage = ERROR_MESSAGE()

					SELECT @responseMessage AS [Message]
				END CATCH
			END";

            migrationBuilder.Sql(InsertOrUpdateUserwithPassword);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPasswords");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.Sql(@"DROP PROCEDURE GetUserValidation");

            migrationBuilder.Sql(@"DROP PROCEDURE InsertUserwithPassword");

			migrationBuilder.Sql(@"DROP PROCEDURE InsertOrUpdateUserwithPassword");
		}
    }
}
