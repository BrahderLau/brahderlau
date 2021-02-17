/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package online.course.registration.system.pkg1.pkg0;
import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.util.Scanner;
import javax.swing.JOptionPane;
/**
 *
 * @author Lau Kah Hou
 */
public class User {
    protected String user_id, pwd, temp_id, temp_pwd, file_path;
    protected static Scanner x;
    boolean found = false;

    /*                   - Static Variable Explanatins - 
    Static property are associated to the class directly. they can be called even without creating an instance of the class, 
    ex: ClassName.propertyName
    
    
                         - File Methods Explanations -
    Although FileReader is pretty easy to use, it’s advisable to always wrap it with BuffereReader, when reading a file.

    This is because BufferedReader uses a char buffer to simultaneously read multiple values from a character-input stream 
    and hence reduces the number of read() calls made by the underlying FileStream.

    Constructors for BufferedReader take Reader as input. Additionally, we can also provide buffer size in the constructors, 
    but, for most use cases, the default size is large enough:
    
    In addition to the inherited methods from the Reader class, BufferedReader also provides readLine() method, 
    to read an entire line as a String.
    
                         - Gettter & Setter Explanations -
    
    The idea of getters and setters are to control access to variables in a class. 
    That way, if the value needs to be changed internally to be represented in a different way, 
    you can do so without breaking any code outside the class.

    For example, let's say you had a class with a distance variable, and it was measured in inches. 
    A few months pass, you're using this class in a lot of places and you suddenly realize 
    you needed to represent that value in centimeters. 
    If you didn't use a getter and a setter, you would have to track down every use of the class and convert there. 
    If you used a getter and a setter, you can just change those methods and everything that uses the class won't break.
    */
    
    //method to retrieve the user id in the object
    public String getUser_id() {
        return this.user_id;
    }

    //Method to set the user id in the object
    public void setUser_id(String user_id) {
        this.user_id = user_id; //stores the user id
    }
    
    public String getPwd() {
        return this.pwd;
    }

    public void setPwd(String pwd) {
        this.pwd = pwd;
    }
    
    public String getFile_path() {
        return this.file_path;
    }

    public void setFile_path(String file_path) {
        this.file_path = file_path;
    }
        
        
    boolean VerifyLogin(String userID, String password, String filepath) {
        found = false;
        try{
            user_id = userID;
            pwd = password;
            file_path = filepath;
            x = new Scanner(new BufferedReader (new FileReader(file_path)));
            x.useDelimiter("[,\n]"); //String pattern in the textfile
            while (x.hasNext())
            {
                temp_id = x.next();
                temp_pwd = x.next();               
                if (temp_id.trim().equals(user_id.trim()) && temp_pwd.trim().equals(pwd.trim()))
                {
                    found = true;
                    JOptionPane.showMessageDialog(null, "Login Successful!");
                    break;
                }
                else{
                    x.nextLine();
                }
            }
        }
        catch(FileNotFoundException e){
            JOptionPane.showMessageDialog(null,e);
        }
        return found;
    }
}
