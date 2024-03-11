# Concert

## RABOTA SO BAZA
- koga ke napravime modeli vo tools -> nuget console -> add-migration {ime} -> update-database
  vo slucaj na error -> remove-migration i pa nanovo

 - pri sekoja promena na modelot se pravi proceduralno

-  vo ApplicationDbContext gi pisuvame vie linii 
 	public virtual DbSet<ConcertLab> Concerts { get; set; }

	public virtual DbSet<Ticket> Tickets { get; set; }

	public virtual DbSet<ConcertAppUser> ConcertAppUsers { get; set; }

- Ako zaglavime pri promena vo modelot da ne vrati na pocetok (brishe se) 
        update-database -migration: 0
   
	add-migration sekeiskrsam

	update-database

## RABOTA SO MODELI

- koga kreirame modeli gi updateirame vo program.cs na sekoe mesto kaj so pisue IDENTITY USER
   posle menuvame vo ApplicationDbContext 

 - promena vo Views -> Shared -> LoginPartial -> na mestoto kade so ima IDENTITY USER menuvame vo nasiot user
	@inject SignInManager<ConcertAppUser> SignInManager
	@inject UserManager<ConcertAppUser> UserManager

## UREDUVANJE NA REGISTER
 - desen klik na .WEB file -> add new scaffolded item -> identity ->  ako biras za registriranje birash 
	acc/register,  ako sakas za login acc/login i gg
