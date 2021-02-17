#pragma once
#include <string>
using namespace std;

struct orderInfo { //This struct is to record the order lists.
	int id = 0, ch, qty, tel, itemSize; //since the items ordered cant be modified, we just need to display or delete all the items in the order.
	double price, totalPrice;
	string fname, rname, address, isFulfilled;
	orderInfo* prevOrder;
	orderInfo* next;//This is to declare the next pointer to the item in the list.
	orderInfo* nextOrder;//This is to declare the next pointer to the other order in the list.
};

struct deliveryInfo {
	int id = 0, tel;
	double totalPrice;
	string rname, address, isFulfilled;
	deliveryInfo* nextDelivery;
};

class Item //This class contains all the core functions for the food order and delivery system
{
private:
	const string food_item[5] = {"Burger", "Spaghetti", "Ayam goreng", "Coke", "Sprite"}; //I use array here because the number of items are known.
	const double food_price[5] = {6.00, 10.00, 4.00, 2.00, 2.00}; //I use array here because the price are fixed.
	const double del_fee = 1.05; //Delivery charge 5%
	int size, itemSize, orderSize, ch, subCh, num, qty, id, tel;
	double price,totalPrice;
	bool isFound; //This boolean act as a flag to show whether the order is found or not.
	string name, rname, address, isFulfilled, opt, ans, deletedName;
	deliveryInfo* headD;
	deliveryInfo* last;
	orderInfo* head; // first node of the order list
	orderInfo* tail; // last node of the order list
	orderInfo* toBeDeleted; //order to be deleted
	orderInfo* itemsToBeDeleted; //items to be deleted
	orderInfo* tempOrder; //so that can move to other order after going through the items of the order

public:
	Item();
	~Item();
	void displayMainMenu();

	// Order section
	void displayMenu();
	void createOrder();
	void addItem(int,string,int,double);
	void insertOrderInfo(string,int,string,double);
	void calcPrice(int,double);
	void generateInvoice();

	// Search section
	void searchByOrderNum(int);
	void searchByRName(string);
	void deleteOrder();
	void modifyRName(string);
	void modifyAddr(string);
	void modifyTel(int);

	// Display section
	void displayOrderInfo();
	void deleteFirst();
	void displayDeliveryInfo();
	void fulfillOrder();
};



