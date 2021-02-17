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

/**
 *
 * @author Lau Kah Hou
 */
public class Admin extends User{
    String Adminid;
    String Pwd;
    List<String> studentList = new ArrayList();
    
    public Admin(){
        super();
    }
    
    public List<String> getStudentList(){
        try{
            x = new Scanner(new BufferedReader (new FileReader("Student.txt")));
            x.useDelimiter("[,\n]"); //String pattern in the textfile
            while (x.hasNext()){
                studentList.add(x.next());
                x.nextLine();
            }
        }
        catch(FileNotFoundException e){
            JOptionPane.showMessageDialog(null,e);
        } 
        return studentList;
    }
}
