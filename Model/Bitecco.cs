namespace Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Bitecco : DbContext
    {
        public Bitecco()
            : base("name=Bitecco")
        {
        }

        public virtual DbSet<SYS_Control> SYS_Control { get; set; }
        public virtual DbSet<SYS_Form> SYS_Form { get; set; }
        public virtual DbSet<SYS_Grid> SYS_Grid { get; set; }
        public virtual DbSet<SYS_Menu> SYS_Menu { get; set; }
        public virtual DbSet<SYS_SubMenu> SYS_SubMenu { get; set; }
        public virtual DbSet<SYS_Toolbar> SYS_Toolbar { get; set; }
        public virtual DbSet<SYS_Tree> SYS_Tree { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SYS_Control>()
                .Property(e => e.Status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_Control>()
                .Property(e => e.OrderBy)
                .IsFixedLength();

            modelBuilder.Entity<SYS_Control>()
                .Property(e => e.ApiName)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_Control>()
                .Property(e => e.XML_Link)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_Control>()
                .HasMany(e => e.SYS_Control1)
                .WithOptional(e => e.SYS_Control2)
                .HasForeignKey(e => e.ID_SYS_Control_Parent);

            modelBuilder.Entity<SYS_Form>()
                .Property(e => e.ApiNameConfig)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_Form>()
                .Property(e => e.ApiNameControl)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_Form>()
                .Property(e => e.ApiData)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_Form>()
                .Property(e => e.ApiNameToolbar)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_Form>()
                .Property(e => e.ApiListData)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_Form>()
                .Property(e => e.HelpForm)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_Grid>()
                .Property(e => e.MemberColumn)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_Grid>()
                .Property(e => e.TypeColumn)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_Grid>()
                .Property(e => e.WidthColumn)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_Grid>()
                .Property(e => e.AlignHeader)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_Grid>()
                .Property(e => e.AlignColumn)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_Grid>()
                .Property(e => e.OrderBy)
                .IsFixedLength();

            modelBuilder.Entity<SYS_Grid>()
                .Property(e => e.ApiName)
                .IsFixedLength();

            modelBuilder.Entity<SYS_Menu>()
                .Property(e => e.ControllerName)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_Menu>()
                .Property(e => e.ActionMethod)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_Menu>()
                .Property(e => e.Status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_Menu>()
                .Property(e => e.OrderBy)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_Menu>()
                .HasMany(e => e.SYS_Menu1)
                .WithOptional(e => e.SYS_Menu2)
                .HasForeignKey(e => e.ID_SYS_Menu_Parent);

            modelBuilder.Entity<SYS_SubMenu>()
                .Property(e => e.ControllerName)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_SubMenu>()
                .Property(e => e.ActionMethod)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_Toolbar>()
                .Property(e => e.ToolbarType)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_Toolbar>()
                .Property(e => e.ToolbarImage)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_Toolbar>()
                .Property(e => e.ToolbarDisImage)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_Toolbar>()
                .Property(e => e.ToolbarAction)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_Toolbar>()
                .Property(e => e.OrderBy)
                .IsFixedLength();

            modelBuilder.Entity<SYS_Toolbar>()
                .Property(e => e.ToolbarName)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_Toolbar>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_Toolbar>()
                .HasMany(e => e.SYS_Toolbar1)
                .WithOptional(e => e.SYS_Toolbar2)
                .HasForeignKey(e => e.ID_SYS_Toolbar_Parent);

            modelBuilder.Entity<SYS_Tree>()
                .Property(e => e.ApiName)
                .IsUnicode(false);
        }
    }
}
