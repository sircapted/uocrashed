# uocrashed
my run uo2.6 project.. 
some add on mobs and items
todo: would like to make a vendor that sells only what he buys or savages/rummages... and uses other coin than gold for sales...
      having extra powers to seek rares on occasion...
      
starting myrunuo
this was to connect:

i made these changes to allow my client to fix housing bug associated with client relations
clientverification.cs

public static void Initialize()
		{
			EventSink.ClientVersionReceived += new ClientVersionReceivedHandler( EventSink_ClientVersionReceived );

			//ClientVersion.Required = null;
			//Required = new ClientVersion( "6.0.0.0" );
      
this tells the script where to find the data associated with the server
datapath.cs

private static string CustomPath = @"C:\Program Files (x86)\Electronic Arts";

this is to allow you to connect to your servers ip address
serverlist.cs

public static readonly string Address = "your ip address here";
		public static readonly string ServerName = "your server name here";

		public static readonly bool AutoDetect = true;

