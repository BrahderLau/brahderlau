#include <iomanip>
#include <iostream>
#include "Item.h"


Item::Item()
{
	itemSize = 0;
	orderSize = 0;
	head = nullptr;
	tail = nullptr;
	toBeDeleted = nullptr;
}

Item::~Item()
{
	
}

void Item::displayMainMenu()
{
	while (true) {
		cout << "\n***FOOD ORDER AND DELIVERY SYSTEM***\n" << endl;
		cout << "A. Create a new order" << endl;
		cout << "B. Search for an order" << endl;
		cout << "C. View orders information\n" << endl;
		cout << "What would you like to do?" << endl;
		cin >> opt;
		if (opt == "A" or opt == "a") {
			displayMenu();
			cout << "\n Would you like to return to main menu? y/n" << endl;
			cin >> opt;
			if (opt == "y" or opt == "Y")
				continue;
			else if (opt == "n" or opt == "N") {
				cout << "\nHave a nice day. Bye!" << endl;
				break;
			}
		}
		else if (opt == "B" or opt == "b") {
			cout << "\n\n --------------------------------------" << endl;
			cout << "          SEARCH ORDER OPTIONS             " << endl;
			cout << " --------------------------------------" << endl;
			cout << " 1. Search by Order number " << endl;
			cout << " 2. Search by Recipient name\n " << endl;
			cin >> ch;
			if (ch == 1 || ch == 2) {
				ans = "n";
				if (ch == 1)
					do {
						cout << " Please enter the order number: " << endl;
						cin >> num;
						searchByOrderNum(num);
					} while (ans == "y" || ans == "Y");
				else if (ch == 2) {
					do {
						cout << " Please enter the recipient name: " << endl;
						cin >> opt;
						searchByRName(opt);
					} while (ans == "y" || ans == "Y");
				}
				if (ans == "n" && isFound == true) {
					cout << "\n --------------------------------------" << endl;
					cout << "          MORE ORDER OPTIONS             " << endl;
					cout << " --------------------------------------" << endl;
					cout << " 1. Delete the order " << endl;
					cout << " 2. Modify the order information " << endl;
					cout << " 3. Return to main menu\n " << endl;
					cin >> subCh;

					if (subCh == 1) {
						deleteOrder();
					}
					else if (subCh == 2) {
						do {
							cout << "\n\n --------------------------------------" << endl;
							cout << "             MODIFY OPTIONS             " << endl;
							cout << " --------------------------------------" << endl;
							cout << " \n*Note: Only the recipient name, address and/or\n telephone number attributes may be modified.\n " << endl;
							cout << " 1. Recipient Name " << endl;
							cout << " 2. Address " << endl;
							cout << " 3. Telephone Number\n " << endl;
							cout << " Which information would you like to modify?\n " << endl;
							cin >> subCh;
							switch (subCh) {
							case 1:
								cout << " Please enter new recipient name for the order: " << endl;
								cin >> rname;
								modifyRName(rname);
								cout << " Would you like to modify other information? y/n\n " << endl;
								cin >> ans;
								break;
							case 2:
								cout << " Please enter new address for the order: " << endl;
								cin >> address;
								modifyAddr(address);
								cout << " Would you like to modify other information? y/n\n " << endl;
								cin >> ans;
								break;
							case 3:
								cout << " Please enter new telephone number for the order: " << endl;
								cin >> tel;
								modifyTel(tel);
								cout << " Would you like to modify other information? y/n\n " << endl;
								cin >> ans;
								break;
							default:
								cin.clear(); //clears the error state
								cin.ignore(10000, '\n'); //this clears out any everything in the stream-
								cout << "Invalid Option. Please Try Again." << endl;
							}
						} while (ans == "y" || ans == "Y");
					}
					else if (subCh == 3) {
						continue;
					}
					else {
						cin.clear(); //clears the error state
						cin.ignore(10000, '\n'); //this clears out any everything in the stream
						cout << "Invalid Option. Please Try Again." << endl;
					}
				}
			}
			else {
				cin.clear(); //clears the error state
				cin.ignore(10000, '\n'); //this clears out any everything in the stream
				cout << "Invalid Option. Please Try Again." << endl;
			}
			//break;
		}
		else if (opt == "C" or opt == "c") {
			if (orderSize == 0)
				cout << "\nNo record in the list\n";
			else
				while (orderSize != 0) {
					displayOrderInfo();
					if (opt == "y" or opt == "Y")
						fulfillOrder();
					else
						break;
				}
		}
		else {
			cin.clear(); //clears the error state
			cin.ignore(10000, '\n'); //this clears out any everything in the stream
			cout << "Invalid Option. Please Try Again." << endl;
		}
	}
}

void Item::displayMenu()
{
	itemSize = 0;
	totalPrice = 0;
	createOrder();
	while (true) {
		cout << "\n\n ----------------------------" << endl;
		cout << "          FOOD MENU          " << endl;
		cout << " ----------------------------" << endl;
		cout << " Num" << "      Items    " << "  Price " << endl;
		cout << "  " << 1 << "   Burger      " << "  RM  6.00 " << endl;
		cout << "  " << 2 << "   Spaghetti   " << "  RM 10.00 " << endl;
		cout << "  " << 3 << "   Ayam goreng " << "  RM  4.00 " << endl;
		cout << "  " << 4 << "   Coke        " << "  RM  2.00 " << endl;
		cout << "  " << 5 << "   Sprite      " << "  RM  2.00 \n" << endl;
		cout << "Please choose an item from 1 to 5:" << endl;
		cin >> ch;
		//Here i dont use switch case because i can use an array to minimise the statements for each food item.
		//Using the range of numbers, i do not need to repeat the similar statements.
		if (ch > 0 and ch < 6) {
			cout << "How many " << food_item[ch - 1] << " do you want?" << endl;
			cin >> qty;
			if (qty > 0) {
				price = food_price[ch - 1];
				name = food_item[ch - 1];
				calcPrice(qty,price); //Calculate total price of this item based on the quantity.
				addItem(ch,name,qty,price); //This method adds item into temporary food cart.
				cout << "\nDo you still want to order another item? (y/n)" << endl;
				cin >> opt;
				if (opt == "y" or opt == "Y") {
					continue;
				}
				else if (opt == "n" or opt == "N") {
					totalPrice *= del_fee;
					cout << "Please enter receipient name:" << endl;
					cin >> rname;
					cout << "Please enter receipient telephone number:" << endl;
					cin >> tel;
					cout << "Please enter receipient address:" << endl;
					cin >> address;
					insertOrderInfo(rname, tel, address, totalPrice);
					generateInvoice(); //Here shows the order invoice
					break;
				}
				else {
					cin.clear(); //clears the error state
					cin.ignore(10000, '\n'); //this clears out any everything in the stream
					cout << "Invalid Option. Please Try Again." << endl;
				}
			}
			else {
				cin.clear(); //clears the error state
				cin.ignore(10000, '\n'); //this clears out any everything in the stream
				cout << "Invalid Option. Please Try Again." << endl;
			}
		}
		else { //in case cin fails because the variable is not int (as declared above), it will cause infinite while loop
			cin.clear(); //clears the error state
		    cin.ignore(10000, '\n'); //this clears out any everything in the stream
			cout << "Invalid Option. Please Try Again." << endl;

		    //Reference: http://www.cplusplus.com/forum/general/207458/
		}
	}
}

void Item::createOrder()
{
	id++;
	orderInfo* newOrder = new orderInfo; //this means to create a new node
	newOrder->id = id;
	newOrder->next = nullptr;
	newOrder->nextOrder = nullptr;
	newOrder->prevOrder = tail;
	tail = newOrder;
	if (head == nullptr)
		head = newOrder;
	else {
		newOrder-> prevOrder-> nextOrder = newOrder;
	}
	orderSize++;
}

void Item::addItem(int ch,string name,int qty,double price)
{
	orderInfo* newItem = new orderInfo; //this means to create a new node
	newItem->ch = ch;
	newItem->fname = name;
	newItem->qty = qty;
	newItem->price = price;
	newItem->next = nullptr;
	int count = 0;
	orderInfo* current = tail;
	while (current->next != nullptr) {
		count++;
		current = current->next;
	}
	current->next = newItem;
	itemSize++;
}

void Item::calcPrice(int qty, double price) //Calculate total price of this item based on the quantity.
{
	totalPrice += (qty * price);
}

void Item::insertOrderInfo(string name, int tel, string address, double price)
{
	orderInfo* current = tail;
	current->id = id;
	current->rname = name;
	current->tel = tel;
	current->address = address;
	current->totalPrice = price;
	current->isFulfilled = "N";
	current->itemSize = itemSize;
}

void Item::generateInvoice()
{
	cout << "\n\n --------------------------------------" << endl;
	cout << "                INVOICE              " << endl;
	cout << " --------------------------------------" << endl;
	if (head == nullptr)
		cout << "No record in the list\n" << endl;
	else {
		orderInfo* current = tail;
		cout << " Order ID: " << current->id << "\n Recipient name: " << current->rname << "\n Telephone number: " << current->tel \
			<< "\n Address: " << current->address << "\n Total Amount: RM" << fixed << setprecision(2) << current->totalPrice \
			<< "\n Fulfilled status: " << current->isFulfilled << endl;
		cout << "\n Num" << "      Items    " << "    Quantity " << "  Price(per qty) " << endl;
		current = current->next;
		while (current != nullptr) {
			cout << "  " << current->ch << "\t" << current->fname << "    \t  " << current->qty << "   \t  RM" << current->price << endl;
			current = current->next;
		}
		cout << "\n Order created at: " << __TIMESTAMP__ << endl; //This is the built in function to show the current date and time.
	}
}

void Item::searchByOrderNum(int orderid)
{
	isFound = false;
	if (orderid>0 || orderid<=orderSize) {
		if (orderSize == 1) { //only one item
			orderInfo* current = head;
			if (orderid == current->id) {
				isFound = true;
				cout << " Order ID: " << current->id << "\n Recipient name: " << current->rname << "\n Telephone number: " << current->tel \
					<< "\n Address: " << current->address << "\n Total Amount: RM" << fixed << setprecision(2) << current->totalPrice \
					<< "\n Fulfilled status: " << current->isFulfilled << endl;
				cout << "\n Num" << "      Items    " << "    Quantity " << "  Price(per qty) " << endl;
				current = current->next;
				while (current != nullptr) {
					cout << "  " << current->ch << "\t" << current->fname << "    \t  " << current->qty << "   \t  RM" << current->price << endl;
					current = current->next;
				}
			}
			else {
				cin.clear(); //clears the error state
				cin.ignore(10000, '\n'); //this clears out any everything in the stream
				cout << " Order not found. Would you like to try again? y/n " << endl;
				cin >> ans;
			}
		}
		else if (orderid >= orderSize / 2 && orderSize != 0) { // start from tail
			orderInfo* current = tail;
			int count = 0;
			while (current != nullptr) { // the search enters this while loop three times.
				if (orderid == current->id) {
					isFound = true;
					id = current->id;
					break;
				}
				current = current->prevOrder;
				count++;
			}
			if (isFound == true) {
				cout << " Order ID: " << current->id << "\n Recipient name: " << current->rname << "\n Telephone number: " << current->tel \
					<< "\n Address: " << current->address << "\n Total Amount: RM" << fixed << setprecision(2) << current->totalPrice \
					<< "\n Fulfilled status: " << current->isFulfilled << endl;
				cout << "\n Num" << "      Items    " << "    Quantity " << "  Price(per qty) " << endl;
				current = current->next;
				while (current != nullptr) {
					cout << "  " << current->ch << "\t" << current->fname << "    \t  " << current->qty << "   \t  RM" << current->price << endl;
					current = current->next;
				}
			}
			else {
				cin.clear(); //clears the error state
				cin.ignore(10000, '\n'); //this clears out any everything in the stream
				cout << " Order not found. Would you like to try again? y/n " << endl;
				cin >> ans;
			}
		}
		else if (orderSize != 0){ //start from head;
			orderInfo* current = head;
			while (current != nullptr) {
				if (orderid == current->id) {
					isFound = true;
					id = current->id;
					break;
				}
				current = current->nextOrder;
			}
			if (isFound == true) {
				cout << " Order ID: " << current->id << "\n Recipient name: " << current->rname << "\n Telephone number: " << current->tel \
					<< "\n Address: " << current->address << "\n Total Amount: RM" << fixed << setprecision(2) << current->totalPrice \
					<< "\n Fulfilled status: " << current->isFulfilled << endl;
				cout << "\n Num" << "      Items    " << "    Quantity " << "  Price(per qty) " << endl;
				current = current->next;
				while (current != nullptr) {
					cout << "  " << current->ch << "\t" << current->fname << "    \t  " << current->qty << "   \t  RM" << current->price << endl;
					current = current->next;
				}
			}
			else {
				cin.clear(); //clears the error state
				cin.ignore(10000, '\n'); //this clears out any everything in the stream
				cout << " Order not found. Would you like to try again? y/n " << endl;
				cin >> ans;
			}
		}
		else {
			cin.clear(); //clears the error state
			cin.ignore(10000, '\n'); //this clears out any everything in the stream
			cout << " Order not found. Would you like to try again? y/n " << endl;
			cin >> ans;
		}
	}
	else {
		cin.clear(); //clears the error state
		cin.ignore(10000, '\n'); //this clears out any everything in the stream
		cout << " Order not found. Would you like to try again? y/n " << endl;
		cin >> ans;
	}
}

void Item::searchByRName(string name)
{
	isFound = false;
	if (orderSize > 0) {
		orderInfo* current = tail;
		while (current != nullptr) {
			if (name == current->rname) {
				isFound = true;
				id = current->id;
				break;
			}
			current = current->prevOrder;
		}
		if (isFound == true) {
			cout << " Order ID: " << current->id << "\n Recipient name: " << current->rname << "\n Telephone number: " << current->tel \
				<< "\n Address: " << current->address << "\n Total Amount: RM" << fixed << setprecision(2) << current->totalPrice \
				<< "\n Fulfilled status: " << current->isFulfilled << endl;
			cout << "\n Num" << "      Items    " << "    Quantity " << "  Price(per qty) " << endl;
			current = current->next;
			while (current != nullptr) {
				cout << "  " << current->ch << "\t" << current->fname << "    \t  " << current->qty << "   \t  RM" << current->price << endl;
				current = current->next;
			}
		}
		else {
			cout << " Order not found. Would you like to try again? y/n " << endl;
			cin >> ans;
		}
	}
	else {
		cout << " Order not found. Would you like to try again? y/n " << endl;
		cin >> ans;
	}
}

void Item::deleteOrder()
{
	if (orderSize == 1){ //if only one order.
		delete head;
		orderSize--;
	}
	else if (id == tail->id && orderSize>1) { //if the order to be deleted is the last order.
		orderInfo* toBeDeleted = tail;
		tail = tail->prevOrder;
		tail->nextOrder = nullptr;
		orderInfo* current = toBeDeleted->next;
		orderInfo* itemsToBeDeleted = nullptr;
		while (current != nullptr) {
			itemsToBeDeleted = current;
			current = current->next;
			delete itemsToBeDeleted;
		}
		//should i declare toBeDeleted->next = null?
		delete toBeDeleted;
		orderSize--;	
	}
	else if (id == head->id) { //if the order to be deleted is the first order.
		orderInfo* toBeDeleted = head;
		head = head->nextOrder;
		orderInfo* current = toBeDeleted->next;
		orderInfo* itemsToBeDeleted = nullptr;
		while (current != nullptr) {
			itemsToBeDeleted = current;
			current = current->next;
			delete itemsToBeDeleted;
		}
		//should i declare toBeDeleted->next = null?
		delete toBeDeleted;
		orderSize--;

		if (head == NULL)
			tail = NULL;
	}
	else if (id >= orderSize / 2) { //if the id of the order to be deleted is more than half of the size
		orderInfo* toBeDeleted = tail;
		while (toBeDeleted != nullptr) {
			if (id == toBeDeleted->id)
				break;
			toBeDeleted = toBeDeleted->prevOrder;
		}
		toBeDeleted->prevOrder->nextOrder = toBeDeleted->nextOrder;
		toBeDeleted->nextOrder->prevOrder = toBeDeleted->prevOrder;
		orderInfo* current = toBeDeleted->next;
		orderInfo* itemsToBeDeleted = nullptr;
		while (current != nullptr) {
			itemsToBeDeleted = current;
			current = current->next;
			delete itemsToBeDeleted;
		}
		//should i declare toBeDeleted->next = null?
		delete toBeDeleted;
		orderSize--;
	}
	else { //if the id of the order to be deleted is less than half of the size
		orderInfo* toBeDeleted = head;
		while (toBeDeleted != nullptr) {
			if (id == toBeDeleted->id)
				break;
			toBeDeleted = toBeDeleted->nextOrder;
		}
		toBeDeleted->prevOrder->nextOrder = toBeDeleted->nextOrder;
		toBeDeleted->nextOrder->prevOrder = toBeDeleted->prevOrder;
		orderInfo* current = toBeDeleted->next;
		orderInfo* itemsToBeDeleted = nullptr;
		while (current != nullptr) {
			itemsToBeDeleted = current;
			current = current->next;
			delete itemsToBeDeleted;
		}
		//should i declare toBeDeleted->next = null?
		delete toBeDeleted;
		orderSize--;
	}
}

void Item::modifyRName(string newName)
{
	orderInfo* current = head;
	while (current != nullptr) {
		if (id == current->id) {
			current->rname = newName;
			break;
		}
		current = current->nextOrder;
	}
}

void Item::modifyAddr(string newAddress)
{
	address = newAddress;
	orderInfo* current = head;
	while (current != nullptr) {
		if (id == current->id) {
			current->address = address;
			break;
		}
		current = current->nextOrder;
	}
}

void Item::modifyTel(int newTel)
{
	tel = newTel;
	orderInfo* current = head;
	while (current != nullptr) {
		if (id == current->id) {
			current->tel = tel;
			break;
		}
		current = current->nextOrder;
	}
}

void Item::displayOrderInfo()
{

	cout << "\n\n --------------------------------------" << endl;
	cout << "            Order List                 " << endl;
	cout << " --------------------------------------" << endl;
	if (head == nullptr)
		cout << "\nNo record in the list\n";
	else {
		orderInfo* current = head;
		while (current != nullptr) {
			tempOrder = current;
			cout << "\n\tOrder ID: " << current->id << "\n\n Customer name: " << current->rname << "\n Phone number: " << current->tel \
				<< "\n Address: " << current->address << "\n Total Amount: RM" << fixed << setprecision(2) << current->totalPrice \
				<< "\n Fulfilled status: " << current->isFulfilled << endl;
			current = current->next;
			cout << "\n Num" << "      Items    " << "    Quantity " << "  Price(per qty) " << endl;
			while (current != nullptr){
				cout << "  " << current->ch << "\t" << current->fname << "    \t  " << current->qty << "   \t  RM" << current->price << endl;
				current = current->next;
			}
			cout << "\n-----------------------------------------------" << endl;
			current = tempOrder->nextOrder;
		}
		cout << "\nWould you like to fulfill the first order? y/n" << endl;
		cin >> opt;
	}
}

void Item::deleteFirst()
{	
	orderInfo* toBeDeleted = head;
	head = head->nextOrder;
	orderInfo* current = toBeDeleted->next;
	orderInfo* itemsToBeDeleted = nullptr;
	while (current != nullptr) {
		itemsToBeDeleted = current;
		current = current->next;
		delete itemsToBeDeleted;
	}
	delete toBeDeleted;
	orderSize--;

	if (head == NULL)
		tail = NULL;
}

void Item::displayDeliveryInfo()
{
	cout << "\n\n --------------------------------------" << endl;
	cout << "            Delivery List                 " << endl;	
	if (headD == nullptr)
		cout << "\nNo record in the list\n";
	else {
		deliveryInfo* current = headD;
		while (current != nullptr) {
			cout << " --------------------------------------" << endl;
			cout << "\n\tOrder ID: " << current->id << "\n\n Customer name: " << current->rname << "\n Phone number: " << current->tel \
				<< "\n Address: " << current->address << "\n Total Amount: RM" << fixed << setprecision(2) << current->totalPrice \
				<< "\n Fulfilled status: " << current->isFulfilled << endl;
			current = current->nextDelivery;
		}
	}
}

void Item::fulfillOrder()
{
	if (head == nullptr)
		cout << "No record in the list\n";
	else {
		orderInfo* current = head;
		current->isFulfilled = "F";
		deliveryInfo* toBeDelivered = new deliveryInfo;
		toBeDelivered->id = current->id;
		toBeDelivered->rname = current->rname;
		toBeDelivered->tel = current->tel;
		toBeDelivered->address = current->address;
		toBeDelivered->totalPrice = current->totalPrice;
		toBeDelivered->isFulfilled = current->isFulfilled;
		toBeDelivered->nextDelivery = nullptr;

		if (headD == nullptr)
			headD = toBeDelivered;
		else {
			deliveryInfo* last = headD;
			while (last->nextDelivery != nullptr)
				last = last->nextDelivery;
			last->nextDelivery = toBeDelivered;
		}
		displayDeliveryInfo();
		deleteFirst();
	}
}










