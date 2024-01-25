# ertekeloRendszer

<h1>Tanári értékelő rendszer - backend / swagger</h1>
A táblák közül a getter nézettábla és a végsőpont nézettábla, így bennük az adatokat nem lehet megváltoztatni,
csak úgy, ha átírjuk a hozzájuk tartozó 3 táblát: Screening, Szempont, Ertekelesek
<h4>A DB-t leképezendő létre kell hozni a modeleket a következő paranccsal</h4> <br>(VS -> tools -> Nuget Package Menager -> Package Menager Console-ból adjuk ki):<br>
Scaffold-DbContext "server=localhost;database=ertekelo-rendszer;user=root;password=;ssl mode=none;" mysql.entityframeworkcore -outputdir Models -f<br>
Figyeljünk a helyes DB-hozzáférés beállításaira valamint <b>production-ben</b> hozzunk létre SZIGORÚAN olyan usert, akinek kellő hozzáférése van,<br>
ugyanakkor figyeljünk oda, hogy <b>drop table / drop database hozzáférése ne legyen</b>!!!
