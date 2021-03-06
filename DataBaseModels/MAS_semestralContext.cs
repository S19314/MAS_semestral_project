using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MAS_semestral_project_MVS.Services;

#nullable disable

namespace MAS_semestral_project_MVS.DataBaseModels
{
    public partial class MAS_semestralContext : DbContext
    {
        public MAS_semestralContext()
        {
            
        }

        public MAS_semestralContext(DbContextOptions<MAS_semestralContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<ClassAttribute> ClassAttributes { get; set; }
        public virtual DbSet<CleaningGroup> CleaningGroups { get; set; }
        public virtual DbSet<CleaningTool> CleaningTools { get; set; }
        public virtual DbSet<CustomerConversation> CustomerConversations { get; set; }
        public virtual DbSet<KnowedLanguage> KnowedLanguages { get; set; }
        public virtual DbSet<LanguageEmployee> LanguageEmployees { get; set; }
        public virtual DbSet<LastCleanedRoom> LastCleanedRooms { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PlaceWork> PlaceWorks { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<ClassAttributesInColumn> ClassAttributesInColumns { get; set; }

        public virtual DbSet<ConnectionItemPage> ConnectionItemPages { get; set; }
        public virtual DbSet<MenuBarItem> MenuBarItems { get; set; }
        public virtual DbSet<WebPage> WebPages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-QBPEBIC\\DEVELOPERDB;Initial Catalog=MAS_semestral;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<ClassAttribute>(entity =>
            {
                entity.HasKey(e => e.IdAttribute)
                    .HasName("ClassAttributes_pk");

                entity.Property(e => e.NameAttribut).HasColumnName("nameAttribut");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<CleaningGroup>(entity =>
            {
                entity.HasKey(e => e.IdGroup)
                    .HasName("CleaningGroup_pk");

                entity.ToTable("CleaningGroup");

                entity.Property(e => e.IdGroup).ValueGeneratedNever();

                entity.Property(e => e.EndWorkTime).HasColumnType("datetime");

                entity.Property(e => e.IdAttribute).ValueGeneratedOnAdd();

                entity.Property(e => e.StartWorkTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<CleaningTool>(entity =>
            {
                entity.HasKey(e => e.IdTool)
                    .HasName("CleaningTools_pk");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OsobaIdOsoba).HasColumnName("Osoba_IdOsoba");

                entity.HasOne(d => d.OsobaIdOsobaNavigation)
                    .WithMany(p => p.CleaningTools)
                    .HasForeignKey(d => d.OsobaIdOsoba)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CleaningTools_Osoba");
            });
            /* OLD *//*
            modelBuilder.Entity<CustomerConversation>(entity =>
            {
                entity.HasKey(e => new { e.ClientIdOsoba, e.EmployeeIdOsoba })
                    .HasName("CustomerConversation_pk");

                entity.ToTable("CustomerConversation");

                entity.Property(e => e.ClientIdOsoba).HasColumnName("Client_IdOsoba");

                entity.Property(e => e.EmployeeIdOsoba).HasColumnName("Employee_IdOsoba");

                entity.Property(e => e.EndDateTime).HasColumnType("datetime");

                entity.Property(e => e.StartDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.ClientIdOsobaNavigation)
                    .WithMany(p => p.CustomerConversationClientIdOsobaNavigations)
                    .HasForeignKey(d => d.ClientIdOsoba)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CustomerConversation_Client");

                entity.HasOne(d => d.EmployeeIdOsobaNavigation)
                    .WithMany(p => p.CustomerConversationEmployeeIdOsobaNavigations)
                    .HasForeignKey(d => d.EmployeeIdOsoba)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CustomerConversation_Employee");
            });
            */
            modelBuilder.Entity<CustomerConversation>(entity =>
            {
                entity.HasKey(e => e.IdCustomerConversation)
                    .HasName("CustomerConversation_pk");

                entity.ToTable("CustomerConversation");

                entity.Property(e => e.IdCustomerConversation).ValueGeneratedNever();

                entity.Property(e => e.ClientIdOsoba).HasColumnName("Client_IdOsoba");

                entity.Property(e => e.EmployeIdOsoba).HasColumnName("Employe_IdOsoba");

                entity.Property(e => e.EndDateTime).HasColumnType("datetime");

                entity.Property(e => e.StartDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.ClientIdOsobaNavigation)
                    .WithMany(p => p.CustomerConversationClientIdOsobaNavigations)
                    .HasForeignKey(d => d.ClientIdOsoba)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CustomerConversation_Employee");

                entity.HasOne(d => d.EmployeIdOsobaNavigation)
                    .WithMany(p => p.CustomerConversationEmployeeIdOsobaNavigations)
                    .HasForeignKey(d => d.EmployeIdOsoba)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CustomerConversation_Client");
            });


            modelBuilder.Entity<KnowedLanguage>(entity =>
            {
                entity.HasKey(e => e.IdLanguage)
                    .HasName("KnowedLanguage_pk");

                entity.ToTable("KnowedLanguage");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LanguageEmployee>(entity =>
            {
                entity.HasKey(e => new { e.OsobaIdOsoba, e.KnowedLanguageIdLanguage })
                    .HasName("Language_Employee_pk");

                entity.ToTable("Language_Employee");

                entity.Property(e => e.OsobaIdOsoba).HasColumnName("Osoba_IdOsoba");

                entity.Property(e => e.KnowedLanguageIdLanguage).HasColumnName("KnowedLanguage_IdLanguage");

                entity.HasOne(d => d.KnowedLanguageIdLanguageNavigation)
                    .WithMany(p => p.LanguageEmployees)
                    .HasForeignKey(d => d.KnowedLanguageIdLanguage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Language_Employee_KnowedLanguage");

                entity.HasOne(d => d.OsobaIdOsobaNavigation)
                    .WithMany(p => p.LanguageEmployees)
                    .HasForeignKey(d => d.OsobaIdOsoba)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Language_Employee_Osoba");
            });

            modelBuilder.Entity<LastCleanedRoom>(entity =>
            {
                entity.HasKey(e => e.IdLastCleanedRoom)
                    .HasName("LastCleanedRoom_pk");

                entity.ToTable("LastCleanedRoom");

                entity.Property(e => e.CleaningGroupIdGroup).HasColumnName("CleaningGroup_IdGroup");

                entity.Property(e => e.DurationCleanedTime).HasColumnType("datetime");

                entity.Property(e => e.RoomIdRoom).HasColumnName("Room_IdRoom");

                entity.HasOne(d => d.CleaningGroupIdGroupNavigation)
                    .WithMany(p => p.LastCleanedRooms)
                    .HasForeignKey(d => d.CleaningGroupIdGroup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("LastCleanedRoom_CleaningGroup");

                entity.HasOne(d => d.RoomIdRoomNavigation)
                    .WithMany(p => p.LastCleanedRooms)
                    .HasForeignKey(d => d.RoomIdRoom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("LastCleanedRoom_Room");
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.ToTable("Offer");

                entity.Property(e => e.AvailableFrom).HasColumnType("datetime");

                entity.Property(e => e.AvailableTo).HasColumnType("datetime");

                entity.Property(e => e.OfferStatus)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.RoomIdRoom).HasColumnName("Room_IdRoom");

                entity.Property(e => e.RoomPrice).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.RoomIdRoomNavigation)
                    .WithMany(p => p.Offers)
                    .HasForeignKey(d => d.RoomIdRoom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Offer_Room");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("Order_pk");

                entity.ToTable("Order");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.OfferId).HasColumnName("Offer_Id");

                entity.Property(e => e.Osoba2IdOsoba).HasColumnName("Osoba_2_IdOsoba");

                entity.Property(e => e.OsobaIdOsoba).HasColumnName("Osoba_IdOsoba");

                entity.HasOne(d => d.Offer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OfferId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Offer");

                entity.HasOne(d => d.Osoba2IdOsobaNavigation)
                    .WithMany(p => p.OrderOsoba2IdOsobaNavigations)
                    .HasForeignKey(d => d.Osoba2IdOsoba)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Client");

                entity.HasOne(d => d.OsobaIdOsobaNavigation)
                    .WithMany(p => p.OrderOsobaIdOsobaNavigations)
                    .HasForeignKey(d => d.OsobaIdOsoba)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Employee");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.IdOsoba)
                    .HasName("Person_pk");

                entity.ToTable("Person");

                entity.Property(e => e.CleaningGroupIdGroup).HasColumnName("CleaningGroup_IdGroup");

                entity.Property(e => e.EmployeeExperienceType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.HourRate).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.LastDateChangeRate).HasColumnType("datetime");

                entity.Property(e => e.PassportData)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RelationWithCompany)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SecondName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.WorkShift)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.CleaningGroupIdGroupNavigation)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.CleaningGroupIdGroup)
                    .HasConstraintName("Osoba_CleaningGroup");
            });

            modelBuilder.Entity<PlaceWork>(entity =>
            {
                entity.HasKey(e => e.IdPlaceWork)
                    .HasName("PlaceWork_pk");

                entity.ToTable("PlaceWork");

                entity.Property(e => e.EmployeeIdPerson).HasColumnName("Employee_IdPerson");

                entity.Property(e => e.Name)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.EmployeeIdPersonNavigation)
                    .WithMany(p => p.PlaceWorks)
                    .HasForeignKey(d => d.EmployeeIdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PlaceWork_Person");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.IdRoom)
                    .HasName("Room_pk");

                entity.ToTable("Room");

                entity.Property(e => e.RoomDescription)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.RoomType)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<ClassAttributesInColumn>(entity =>
            {
                entity.ToTable("ClassAttributesInColumn");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CleanerMaxHourRate).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CleanerReceptionistMaxHourRate)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Cleaner_Receptionist__MaxHourRate");

                entity.Property(e => e.DirectorMaxHourRate).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.EmployeeMaxHourRate).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ReceptionistMaxHourRate).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<ConnectionItemPage>(entity =>
            {
                entity.HasKey(e => new { e.MenuBarItemIdMenuBarItem, e.WebPageIdWebPage })
                    .HasName("ConnectionItemPage_pk");

                entity.ToTable("ConnectionItemPage");

                entity.Property(e => e.MenuBarItemIdMenuBarItem).HasColumnName("MenuBarItem_IdMenuBarItem");

                entity.Property(e => e.WebPageIdWebPage).HasColumnName("WebPage_IdWebPage");

                entity.HasOne(d => d.MenuBarItemIdMenuBarItemNavigation)
                    .WithMany(p => p.ConnectionItemPages)
                    .HasForeignKey(d => d.MenuBarItemIdMenuBarItem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_18_MenuBarItem");

                entity.HasOne(d => d.WebPageIdWebPageNavigation)
                    .WithMany(p => p.ConnectionItemPages)
                    .HasForeignKey(d => d.WebPageIdWebPage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_18_WebPage");
            });
            modelBuilder.Entity<MenuBarItem>(entity =>
            {
                entity.HasKey(e => e.IdMenuBarItem)
                    .HasName("MenuBarItem_pk");

                entity.ToTable("MenuBarItem");

                entity.Property(e => e.IdMenuBarItem).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<WebPage>(entity =>
            {
                entity.HasKey(e => e.IdWebPage)
                    .HasName("WebPage_pk");

                entity.ToTable("WebPage");

                entity.Property(e => e.IdWebPage).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        /// <summary>
        /// It is a configuation method for initialization static variables in objects. Value for static variables storing in Data Base. That why we should this method during initialization DataContext in DataBaseService.
        /// </summary>
        /// <param name="dataBaseService"></param>
        public void SetServiceInEntities(IDataBaseService dataBaseService)
        {
            Person.DataBaseService = dataBaseService;
        }
    }
}
