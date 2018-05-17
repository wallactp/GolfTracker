using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GolfTracker.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            // migrationBuilder.AlterColumn<int>(
            //     name: "Id",
            //     table: "AspNetUserClaims",
            //     nullable: false,
            //     oldClrType: typeof(int))
            //     .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            // migrationBuilder.AlterColumn<int>(
            //     name: "Id",
            //     table: "AspNetRoleClaims",
            //     nullable: false,
            //     oldClrType: typeof(int))
            //     .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<Guid>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Street1 = table.Column<string>(nullable: true),
                    Street2 = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Club",
                columns: table => new
                {
                    ClubId = table.Column<Guid>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    GripSize = table.Column<string>(nullable: true),
                    GripType = table.Column<string>(nullable: true),
                    Length = table.Column<double>(nullable: false),
                    Lie = table.Column<double>(nullable: false),
                    Loft = table.Column<double>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    ShaftFlex = table.Column<string>(nullable: true),
                    ShaftType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club", x => x.ClubId);
                });

            migrationBuilder.CreateTable(
                name: "HandicapData",
                columns: table => new
                {
                    HandicapDataId = table.Column<Guid>(nullable: false),
                    BackRating = table.Column<double>(nullable: false),
                    BackSlope = table.Column<int>(nullable: false),
                    CourseSlope = table.Column<int>(nullable: false),
                    FrontRating = table.Column<double>(nullable: false),
                    FrontSlope = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HandicapData", x => x.HandicapDataId);
                });

            migrationBuilder.CreateTable(
                name: "HandicapHistory",
                columns: table => new
                {
                    HandicapHistoryId = table.Column<Guid>(nullable: false),
                    BiMonthlyUpdate = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Handicap = table.Column<double>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HandicapHistory", x => x.HandicapHistoryId);
                    table.ForeignKey(
                        name: "FK_HandicapHistory_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Set",
                columns: table => new
                {
                    SetId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Set", x => x.SetId);
                    table.ForeignKey(
                        name: "FK_Set_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(nullable: false),
                    AddressId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Course_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClubInSet",
                columns: table => new
                {
                    ClubInSetId = table.Column<Guid>(nullable: false),
                    ClubId = table.Column<Guid>(nullable: false),
                    SetId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubInSet", x => x.ClubInSetId);
                    table.ForeignKey(
                        name: "FK_ClubInSet_Club_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClubInSet_Set_SetId",
                        column: x => x.SetId,
                        principalTable: "Set",
                        principalColumn: "SetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseTee",
                columns: table => new
                {
                    CourseTeeId = table.Column<Guid>(nullable: false),
                    CourseId = table.Column<Guid>(nullable: false),
                    HandicapDataId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTee", x => x.CourseTeeId);
                    table.ForeignKey(
                        name: "FK_CourseTee_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseTee_HandicapData_HandicapDataId",
                        column: x => x.HandicapDataId,
                        principalTable: "HandicapData",
                        principalColumn: "HandicapDataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeCourse",
                columns: table => new
                {
                    HomeCourseId = table.Column<Guid>(nullable: false),
                    CourseId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCourse", x => x.HomeCourseId);
                    table.ForeignKey(
                        name: "FK_HomeCourse_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeCourse_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hole",
                columns: table => new
                {
                    HoleId = table.Column<Guid>(nullable: false),
                    CourseTeeId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    Par = table.Column<int>(nullable: false),
                    Yardage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hole", x => x.HoleId);
                    table.ForeignKey(
                        name: "FK_Hole_CourseTee_CourseTeeId",
                        column: x => x.CourseTeeId,
                        principalTable: "CourseTee",
                        principalColumn: "CourseTeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Round",
                columns: table => new
                {
                    RoundId = table.Column<Guid>(nullable: false),
                    CourseTeeId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    RoundDetailType = table.Column<int>(nullable: false),
                    RoundLengthType = table.Column<int>(nullable: false),
                    RoundLocationType = table.Column<int>(nullable: false),
                    SetId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Round", x => x.RoundId);
                    table.ForeignKey(
                        name: "FK_Round_CourseTee_CourseTeeId",
                        column: x => x.CourseTeeId,
                        principalTable: "CourseTee",
                        principalColumn: "CourseTeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Round_Set_SetId",
                        column: x => x.SetId,
                        principalTable: "Set",
                        principalColumn: "SetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Round_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HolePlayed",
                columns: table => new
                {
                    HolePlayedId = table.Column<Guid>(nullable: false),
                    FairwayInRegulation = table.Column<int>(nullable: false),
                    GreenInRegulation = table.Column<bool>(nullable: false),
                    HoleId = table.Column<Guid>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    NumberOfPutts = table.Column<int>(nullable: false),
                    RoundId = table.Column<Guid>(nullable: false),
                    SandSave = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    UpAndDown = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolePlayed", x => x.HolePlayedId);
                    table.ForeignKey(
                        name: "FK_HolePlayed_Hole_HoleId",
                        column: x => x.HoleId,
                        principalTable: "Hole",
                        principalColumn: "HoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HolePlayed_Round_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Round",
                        principalColumn: "RoundId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ClubInSet_ClubId",
                table: "ClubInSet",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubInSet_SetId",
                table: "ClubInSet",
                column: "SetId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_AddressId",
                table: "Course",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTee_CourseId",
                table: "CourseTee",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTee_HandicapDataId",
                table: "CourseTee",
                column: "HandicapDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HandicapHistory_UserId",
                table: "HandicapHistory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Hole_CourseTeeId",
                table: "Hole",
                column: "CourseTeeId");

            migrationBuilder.CreateIndex(
                name: "IX_HolePlayed_HoleId",
                table: "HolePlayed",
                column: "HoleId");

            migrationBuilder.CreateIndex(
                name: "IX_HolePlayed_RoundId",
                table: "HolePlayed",
                column: "RoundId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCourse_CourseId",
                table: "HomeCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCourse_UserId",
                table: "HomeCourse",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Round_CourseTeeId",
                table: "Round",
                column: "CourseTeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Round_SetId",
                table: "Round",
                column: "SetId");

            migrationBuilder.CreateIndex(
                name: "IX_Round_UserId",
                table: "Round",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Set_UserId",
                table: "Set",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Address_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Address_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ClubInSet");

            migrationBuilder.DropTable(
                name: "HandicapHistory");

            migrationBuilder.DropTable(
                name: "HolePlayed");

            migrationBuilder.DropTable(
                name: "HomeCourse");

            migrationBuilder.DropTable(
                name: "Club");

            migrationBuilder.DropTable(
                name: "Hole");

            migrationBuilder.DropTable(
                name: "Round");

            migrationBuilder.DropTable(
                name: "CourseTee");

            migrationBuilder.DropTable(
                name: "Set");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "HandicapData");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            // migrationBuilder.AlterColumn<int>(
            //     name: "Id",
            //     table: "AspNetUserClaims",
            //     nullable: false,
            //     oldClrType: typeof(int))
            //     .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            // migrationBuilder.AlterColumn<int>(
            //     name: "Id",
            //     table: "AspNetRoleClaims",
            //     nullable: false,
            //     oldClrType: typeof(int))
            //     .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
