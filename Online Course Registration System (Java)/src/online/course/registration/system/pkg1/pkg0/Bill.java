package online.course.registration.system.pkg1.pkg0;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.util.ArrayList;
import java.util.List;
import java.util.NoSuchElementException;
import java.util.Scanner;
import javax.swing.DefaultListModel;
import javax.swing.JOptionPane;

public class Bill {

    private String bill_id;
    private String student_id;
    private String course_title;
    List<String> bill_list = new ArrayList();
    private Scanner x;
    String tempInfo;

    public String getBill_id() {
            return this.bill_id;
    }

    /**
     * 
     * @param bill_id
     */
    public void setBill_id(String bill_id) {
            this.bill_id = bill_id;
    }

    public String getStudent_id() {
            return this.student_id;
    }

    /**
     * 
     * @param student_id
     */
    public void setStudent_id(String student_id) {
            this.student_id = student_id;
    }

    public String getCourse_title() {
            return this.course_title;
    }

    /**
     * 
     * @param course_title
     */

    public void setCourse_title(String course_title) {
        this.course_title = course_title;
    }

    public boolean ValidateBill(){
        boolean found = false;
        try{          
            x = new Scanner(new BufferedReader (new FileReader("Bill.txt")));
            x.useDelimiter("[,\n]"); //String pattern in the textfile
            while (x.hasNext()){
                if (bill_id.trim().equals(x.next().trim())&&student_id.trim().equals(x.next().trim())){
                    EditFile f = new EditFile();
                    f.changeALineInATextFile("Bill.txt",bill_id+","+student_id+","+course_title, bill_id);
                    found = true;
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
    
    public List<String> generateBill(){
        try{
            x = new Scanner(new BufferedReader (new FileReader("Bill.txt")));
            x.useDelimiter("[,\n]"); //String pattern in the textfile
            while (x.hasNextLine()){
                String line = x.nextLine();
                if (line.isEmpty())
                    continue;
                else if(line.contains(student_id)){
                    String[] tokens = line.split(",");
                    tempInfo = "";
                    for (String token : tokens){
                        if (token.isEmpty())
                            continue;
                        // do whatever processing for each token
                        else{
                            tempInfo += token;
                            tempInfo += "   ";
                        }
                    }
                    bill_list.add(tempInfo);
                }
            }
        }
        catch(FileNotFoundException e){
            JOptionPane.showMessageDialog(null,e);
        }
        catch(NoSuchElementException e){
            // TODO Auto-generated catch block
        }
        return bill_list;
    }
}