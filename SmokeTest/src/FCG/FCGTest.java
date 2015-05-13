/*
 ============================================================================
 Name        : FCGTest.java
 Author      : Erik Nilsson
 Version     : 1.0
 Copyright   : (C) Combitech AB
 Description : Tests to run on card used for FCG
 ============================================================================
 */
package FCG;
import static org.junit.Assert.*;

import org.junit.FixMethodOrder;
import org.junit.Test;
import org.junit.runners.MethodSorters;
import org.junit.Ignore;
import org.sikuli.basics.Debug;
import org.sikuli.basics.Settings;
import org.sikuli.script.App;
import org.sikuli.script.Env;
import org.sikuli.script.FindFailed;
import org.sikuli.script.Key;
import org.sikuli.script.KeyModifier;
import org.sikuli.script.Pattern;
import org.sikuli.script.Screen;

import org.sikuli.script.ImagePath;

/*
This junit test executes 4 different test cases;
	TC001_OS_Test
		Check if the operating system of the machine executing the test(s) is Windows
	TC010_Start_FCG_Test
		Check if it is possible to connect to the card via serial interface
	TC020_Login_FCG_Test
		Check if it is possible to log on to the card
	TC030_Enabled_std_image_FCG_Test
		Check is the card can be rebooted into the std image after new software has been loaded
*/

//Setting the order of the execution of the test cases
//Using TCxxx_ as the start of each test enables the order of the execution
@FixMethodOrder(MethodSorters.NAME_ASCENDING)
public class FCGTest {

	int iTC = 0;
	String testID = "undefined";
	
	//App object
	App appPutty;
	//Computer screen object
	Screen m_screen;
	//Relative folder for images
	String folder = "imgs\\";
	
	//Load all images from file
	Pattern m_minmizeDesktop = new Pattern(folder + "minmizeDesktop.png");
	Pattern m_putty_exe = new Pattern(folder + "putty_exe.png");
	Pattern m_putty = new Pattern(folder + "putty.png");
	Pattern m_FCG_com3 =  new Pattern(folder + "tbos_com3.png");
	Pattern m_load_button = new Pattern(folder + "load_button.png");
	Pattern m_open_button = new Pattern(folder + "open_button.png");
	Pattern m_ok_button = new Pattern(folder + "ok_button.png");
	Pattern m_login_as = new Pattern(folder + "login_as.png");
	Pattern m_x_button = new Pattern(folder + "x_button.png");
	Pattern m_windows_button = new Pattern(folder + "windows_button.png");	
	Pattern m_login_incorrect = new Pattern(folder + "login_incorrect.png");
	Pattern m_password = new Pattern(folder + "password.png");
	Pattern m_service_login = new Pattern(folder + "service_login.png");
	Pattern m_tag_sign = new Pattern(folder + "tag_sign.png");
	Pattern m_std_login = new Pattern(folder + "std_login.png");

	public void minimizeDesktop() throws FindFailed {
		//Minimize desktop & Deselect all icons by clicking in the middle of the screen
		m_screen.click(m_minmizeDesktop.similar((float) 0.8));
		m_screen.wait((double) 1.0);
		m_screen.find(m_windows_button.similar((float) 0.8)).above(500).right(1500).click();
		m_screen.wait((double) 1.0);
	}
	
	public void openPuttyApplication() throws FindFailed {
		//Launch Putty application
		appPutty = App.open("putty.exe");
		m_screen.wait((double) 2.0);
					
		//Test if Putty started
		assertNotNull("ERROR = " + testID + " failed!" + " Putty application did not start!", m_screen.find(m_putty.similar((float) 0.8)));
		m_screen.wait((double) 1.0);
	}
	
	public void loadFCGSettingsInPuttyApplication() throws FindFailed {
		//Load settings for connection i.e. COM3 115220 baud
		m_screen.click(m_FCG_com3.similar((float) 0.8));
		m_screen.click(m_load_button.similar((float) 0.8));
		m_screen.click(m_open_button.similar((float) 0.8));
		m_screen.wait((double) 1.0);
		m_screen.type(Key.ENTER);
		m_screen.wait((double) 1.0);
	}
	
	public void closePuttyApplication() {
		//Close Putty
		appPutty.close();
		m_screen.wait((double) 1.0);
	}
	
	public void loginRootOnCard() {
		m_screen.type("root" + Key.ENTER);
		m_screen.type("root" + Key.ENTER);
	}
	
	public void logoutRootFromCard() {
		m_screen.type("exit" + Key.ENTER);
		m_screen.wait((double) 1.0);
	}
	
	// The test for OS can be used as a framework to create new tests
	@Test
	public void TC001_OS_Test() throws Exception 
	{
		//Setting Sikuli debug level to 3 enables a extended debug output in the console login
		//Debug.setDebugLevel(3);

		testID = "TC001_OS_Test";
		System.out.println("EXECUTE " + testID);

		//try {
			//Check which platform the test are executed on
			if (Settings.isWindows()){
				System.out.println("PASS = " + testID + ", OS is Windows!");
				assertTrue("PASS = " + testID + " passed!", true);
			}
			else if (Settings.isLinux()){
				System.out.println("ERROR = " + testID + ", OS is Linux!");
				assertTrue("ERROR = " + testID + " failed!", false);
			}
			else {
				System.out.println("ERROR = " + testID + ", OS is other!");
				assertTrue("ERROR = " + testID + " failed!", false);
			}
				
		/*}
		catch (FindFailed e){
			System.out.println("ERROR = " + testID + " failed!");
			e.printStackTrace();
			assertTrue("ERROR = " + testID + " failed!", false);
		}*/
		
	}
	
	//Test case checks if possible to login
		@Test
		public void TC010_Start_FCG_Test() throws Exception 
		{
		//Setting Sikuli debug level to 3 enables a extended debug output in the console login
		//Debug.setDebugLevel(3);

			testID = "TC010_Start_FCG_Test";
			System.out.println("EXECUTE " + testID);
			
			try
			{
				//Create Sikuli screen object
				m_screen = new Screen();
			
				minimizeDesktop();
				
				openPuttyApplication();
				
				loadFCGSettingsInPuttyApplication();
				
				//Test if FCG started by validating presens of "login"
				assertNotNull("ERROR = " + testID + " failed!" + " FCG not connected on serial interface!", m_screen.find(m_login_as.similar((float) 0.8)));
				m_screen.wait((double) 1.0);
								
				closePuttyApplication();
				
				minimizeDesktop();
				
				System.out.println("PASS = " + testID);
			}
			catch (FindFailed e)
			{
				System.out.println("ERROR = " + testID + " failed!");
				e.printStackTrace();
				assertTrue("ERROR = " + testID + " failed!", false);
			}
		}


		//Test to see if it is possible to login on FCG
		@Test
		public void TC020_Login_FCG_Test() throws Exception 
		{
		//Setting Sikuli debug level to 3 enables a extended debug output in the console login
		//Debug.setDebugLevel(3);
			testID = "TC020_Login_FCG_Test";
			System.out.println("EXECUTE " + testID);
			
			try
			{
				//Create Sikuli screen object
				m_screen = new Screen();
			
				minimizeDesktop();
				
				openPuttyApplication();
				
				loadFCGSettingsInPuttyApplication();
				
				//Test if FCG started by validating presens of "login"
				assertNotNull("ERROR = " + testID + " failed!" + " FCG not connected on serial interface!", m_screen.find(m_login_as.similar((float) 0.8)));
				m_screen.wait((double) 1.0);

				loginRootOnCard();

				//Test if login worked
				assertNotNull("ERROR = " + testID + " failed!" + " Login to FCG!", m_screen.find(m_tag_sign.similar((float) 0.8)));
				m_screen.wait((double) 1.0);
				
				logoutRootFromCard();
								
				closePuttyApplication();
				
				minimizeDesktop();
				
				System.out.println("PASS = " + testID);
			}
			catch (FindFailed e)
			{
				System.out.println("ERROR = " + testID + " failed!");
				e.printStackTrace();
				assertTrue("ERROR = " + testID + " failed!", false);
			}
		}

		
		//Test to see if std image available (3 times) and then the service image
		//This test takes long time to execute, around 9 minutes
		@Test
		public void TC030_Enabled_std_image_FCG_Test() throws Exception 
		{
		//Setting Sikuli debug level to 3 enables a extended debug output in the console login
		//Debug.setDebugLevel(3);
			testID = "TC030_Enabled_std_image_FCG_Test";
			System.out.println("EXECUTE " + testID);
			
			try
			{
				//Create Sikuli screen object
				m_screen = new Screen();
			
				minimizeDesktop();
				
				openPuttyApplication();
				
				loadFCGSettingsInPuttyApplication();
				
				//Test if FCG started by validating presens of "login"
				assertNotNull("ERROR = " + testID + " failed!" + " FCG not connected on serial interface!", m_screen.find(m_login_as.similar((float) 0.8)));
				m_screen.wait((double) 1.0);

				loginRootOnCard();

				//Test if login worked
				assertNotNull("ERROR = " + testID + " failed!" + " Login to FCG!", m_screen.find(m_tag_sign.similar((float) 0.8)));
				m_screen.wait((double) 1.0);
				
				logoutRootFromCard();
				
				//Reset boot cnt to 0
				m_screen.type("reset_boot_cnt.sh" + Key.ENTER);
				m_screen.type("reboot -d 2" + Key.ENTER);
				
				// wait 120 sec -- Login No 1
				m_screen.wait((double) 120.0);
				m_screen.type(Key.ENTER);
				assertNotNull("ERROR = " + testID + " failed!" + " STD image not available!", m_screen.find(m_std_login.similar((float) 0.8)));
								
				loginRootOnCard();
							
				System.out.println("----Killall manager 1!");
				m_screen.type("killall Manager" + Key.ENTER);
				
				// wait 120 sec -- Login No 2
				m_screen.wait((double) 120.0);
				m_screen.type(Key.ENTER);
				loginRootOnCard();
				
				System.out.println("----Killall manager 2!");
				m_screen.type("killall Manager" + Key.ENTER);
				
				// wait 120 sec -- Login No 3
				m_screen.wait((double) 120.0);
				m_screen.type(Key.ENTER);
				loginRootOnCard();
				
				System.out.println("----Killall manager 3!");
				m_screen.type("killall Manager" + Key.ENTER);
				
				// wait 120 sec
				m_screen.wait((double) 120.0);
				m_screen.type(Key.ENTER);
				
				//Test id std screen
				assertNotNull("ERROR = " + testID + " failed!" + " Service image not available!", m_screen.find(m_service_login.similar((float) 0.8)));
				m_screen.wait((double) 1.0);
				
				loginRootOnCard();

				//Test if login worked
				assertNotNull("ERROR = " + testID + " failed!" + " Failed login!", m_screen.find(m_tag_sign.similar((float) 0.8)));
				
				logoutRootFromCard();
								
				closePuttyApplication();
				
				minimizeDesktop();
				
				System.out.println("PASS = " + testID);
			}
			catch (FindFailed e)
			{
				System.out.println("ERROR = " + testID + " failed!");
				e.printStackTrace();
				assertTrue("ERROR = " + testID + " failed!", false);
			}
		}

	
	//Test case checks if possible to login
		@Test @Ignore
		public void TC999_TESTING_Test() throws Exception 
		{
		//Setting Sikuli debug level to 3 enables a extended debug output in the console login
		//Debug.setDebugLevel(3);
			testID = "TC999_TESTING_Test";
			System.out.println("EXECUTE " + testID);

			System.out.println("################################ START");

			String path = ImagePath.getBundlePath();
			System.out.println("PATH=" + path);
			path = path + "\\imgs";
			System.out.println("PATH_trunc=" + path);
			ImagePath.setBundlePath(path);
			
			//Debug.setDebugLevel(3);
			
			//Computer screen object
			Screen m_screen;

			try
			{
				//Create Sikuli screen object
				m_screen = new Screen();
			
				//Minimize desktop
				m_screen.click("minmizeDesktop");
				
				//Deselect all icons by clicking in the middle of the screen
				m_screen.wait((double) 1.0);
				//m_screen.find(("windows_button").above(500).right(1500).click();
				m_screen.wait((double) 1.0);
				
				//Launch Putty application
				App appPutty = App.open("putty.exe");
				m_screen.wait((double) 2.0);
							
				//Test if Putty started
				//assertNotNull("ERROR = " + testID + " failed!" + " Putty screen not available!", m_screen.find("putty");
				
				//Load settings for connection i.e. COM3 115220 baud
				m_screen.click("FCG_com3");
				m_screen.click("load_button");
				m_screen.click("open_button");
				m_screen.wait((double) 1.0);
				m_screen.type(Key.ENTER);
				m_screen.wait((double) 1.0);
				
				//Test if FCG started by validating presens of "login"
				//assertNotNull("ERROR = " + testID + " failed!" + " FCG screen not available!", m_screen.find("login_as");
				m_screen.wait((double) 1.0);
								
				//Close Putty
				appPutty.close();
				m_screen.wait((double) 1.0);
				
				//Deselect all icons by clicking in the middle of the screen
				m_screen.wait((double) 1.0);
				m_screen.find(m_minmizeDesktop.similar((float) 0.8)).above(500).left(500).click();
				m_screen.wait((double) 1.0);
				
				System.out.println("PASS = " + testID);				
			}
			catch (FindFailed e)
			{
				System.out.println("ERROR = " + testID + " failed!");
				e.printStackTrace();
				assertTrue("ERROR = " + testID + " failed!", false);
			}
		}	
}
