/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package online.course.registration.system.pkg1.pkg0;
import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import javax.swing.JOptionPane;
import static online.course.registration.system.pkg1.pkg0.User.x;

/**
 *
 * @author Lau Kah Hou
 */
public class Student extends User {
    String tempInfo;
    boolean stop = false;
    List<String> studentInfo = new ArrayList();
    
    public Student(){
        super();
    }
        
    public void SaveInfo(String id, String pwd){
        try{
            x = new Scanner(new BufferedReader (new FileReader(file_path)));
            x.useDelimiter("[,\n]"); //String pattern in the textfile
            while (x.hasNext()){
                String line = x.nextLine();
                if (line.isEmpty()){
                    continue;
                }
                else if(line.contains(id)){
                    String[] tokens = line.split(",");
                    for (String token : tokens){
                        if (token.isEmpty())
                            continue;
                        // do whatever processing for each token
                        else{
                            studentInfo.add(token);
                        }
                    }
                }
            }
        }    
        catch(FileNotFoundException e){
            JOptionPane.showMessageDialog(null,e);
        } 
    }
}
