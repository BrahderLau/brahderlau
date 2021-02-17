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
import java.util.NoSuchElementException;
import java.util.Scanner;
import javax.swing.JOptionPane;

/**
 *
 * @author Lau Kah Hou
 */
public class Course {

    List<String> totalCourse = new ArrayList();
    List<String> courseInfo = new ArrayList();
    int indexPos1, indexPos2, indexPos3, response;
    private static Scanner x;
    
    //This is to get all the details for the courses.
    public List<String> GetCourseInfo(){
        try{
            x = new Scanner(new BufferedReader (new FileReader("Course.txt")));
            x.useDelimiter("[,\n]"); //String pattern in the textfile
            while (x.hasNext()){
                x.next();
                for (int i = 0; i < 3 ; i++){ 
                    courseInfo.add(x.next());
                }
                x.nextLine();
            }
        }
        catch(FileNotFoundException e){
            JOptionPane.showMessageDialog(null,e);
        } 
        catch(NoSuchElementException e){
            // TODO Auto-generated catch block
        }
        return courseInfo;
    }
    
    //Set all the course title available in the university.
    public List<String> SetCourse(){
        try{
            x = new Scanner(new BufferedReader (new FileReader("Course.txt")));
            x.useDelimiter("[,\n]"); //String pattern in the textfile
            while (x.hasNext())
            { 
                totalCourse.add(x.next());
                x.nextLine();
            }
        }
        catch(FileNotFoundException e){
            JOptionPane.showMessageDialog(null,e);
        }
        return totalCourse;
    }
    
    //https://docs.oracle.com/javase/7/docs/api/javax/swing/JOptionPane.html
    //https://docs.oracle.com/javase/tutorial/uiswing/components/dialog.html
    //http://www.cs.fsu.edu/~jtbauer/cis3931/tutorial/ui/swing/dialog.html
    
    //This is to get the deatils for the specific course searched. (Used for right click in student dashboard)
    public int generateDetails(String CourseCh, String useWhere){
        try{
            int count = 0;
            for (int i = 0; i < courseInfo.size() ; i++){
                if (totalCourse.get(i).equals(CourseCh)){
                    //Custom button text
                    if (useWhere.equals("search")){
                        Object[] option = {"Return"};
                        response = JOptionPane.showOptionDialog(null,
                            "Course ID & Name: " + CourseCh
                            + "\nCourse Level: " + courseInfo.get(count++)
                            + "\nCourse Duration: " + courseInfo.get(count++)
                            + "\nCourse Fee: " + courseInfo.get(count++),
                            "Search Result",
                            JOptionPane.DEFAULT_OPTION,
                            JOptionPane.INFORMATION_MESSAGE,
                            null, //don't use a custom Icon
                            option, //the titles of buttons
                            option[0]); //the title of the default button
                        break;              
                    }
                    else{
                        Object[] options = {"Drop",
                                            "Return"};
                    
                        response = JOptionPane.showOptionDialog(null,
                            "Course ID & Name: " + CourseCh
                            + "\nCourse Level: " + courseInfo.get(count++)
                            + "\nCourse Duration: " + courseInfo.get(count++)
                            + "\nCourse Fee: " + courseInfo.get(count++),
                            "Search Result",
                            JOptionPane.DEFAULT_OPTION,
                            JOptionPane.INFORMATION_MESSAGE,
                            null, //don't use a custom Icon
                            options, //the titles of buttons
                            options[1]); //the title of the default button
                        break;       
                    }
                }
                count+=3;
            }
        }
        catch(IndexOutOfBoundsException e){
            JOptionPane.showMessageDialog(null,e);
        }
        return response;
    }
    
    public boolean matchCourse(List<String> s_info,String course_title,String bill_id){
        boolean found = false;

        if (s_info.contains(course_title)){
            JOptionPane.showMessageDialog(null,"Course already registered.\nPlease select other course.");
            found = true;
        }
        else if(bill_id.equals("")){
            JOptionPane.showMessageDialog(null,"Please enter a receipt id.");
            found = true;
        }
        return found;
    }
    //Add new course in textfile
    public List<String> addCourse(List<String> s_info,String course_title){
        EditFile f = new EditFile();
        s_info.add(course_title);
        f.changeALineInATextFile("Student.txt",f.arrayListToString(s_info),s_info.get(0));
        JOptionPane.showMessageDialog(null,"Course added successful.");
        return s_info;
    }
    
    //Used in Admin
    public List<String> generateDetails(String courseTitle){
        List<String> detailsList = new ArrayList();
        try{
            x = new Scanner(new BufferedReader (new FileReader("Course.txt")));
            x.useDelimiter("[,\n]"); //String pattern in the textfile
            while (x.hasNext()){
                String line = x.nextLine();
                if (line.isEmpty()){
                    continue;
                }
                else if(line.contains(courseTitle)){
                    String[] tokens = line.split(",");
                    for (String token : tokens){
                        if (token.isEmpty())
                            continue;
                        // do whatever processing for each token
                        else{
                            detailsList.add(token);
                        }
                    }
                }
            }
        }
        catch(FileNotFoundException e){
            JOptionPane.showMessageDialog(null,e);
        }
        return detailsList;
    }
    
    public List<String> getStudentList(String courseTitle){
        List<String> studentList = new ArrayList();
        try{
            x = new Scanner(new BufferedReader (new FileReader("Student.txt")));
            x.useDelimiter("[,\n]"); //String pattern in the textfile
            while (x.hasNext()){
                String line = x.nextLine();
                if (line.isEmpty()){
                    continue;
                }
                else if(line.contains(courseTitle)){
                    String[] tokens = line.split(",");
                    for (String token : tokens){
                        if (token.isEmpty())
                            continue;
                        // do whatever processing for each token
                        else{
                            studentList.add(token);
                            break;
                        }
                    }
                }
            }
        }
        catch(FileNotFoundException e){
            JOptionPane.showMessageDialog(null,e);
        } 
        return studentList;
    }
}
