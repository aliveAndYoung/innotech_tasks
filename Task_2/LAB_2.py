
# -------------------------
# Basics Section
# -------------------------

# (1) -->  Convert inches to centimeters
def inches_to_cm():
    inches = float(input("Enter length in inches: "))
    cm = inches * 2.54
    print(f"Length in cm: {cm:.2f}")

# (2) -->  Celsius to Fahrenheit
def celsius_to_fahrenheit():
    c = float(input("Enter temperature in Celsius: "))
    f = (c * 9/5) + 32
    print(f"Temperature in Fahrenheit: {f:.2f}")

# (3) -->  Volume of a sphere
def volume_of_sphere():
    radius = float(input("Enter the radius of the sphere: "))
    volume = (4/3) * 3.14159 * radius ** 3
    print(f"Volume of the sphere: {volume:.2f}")

# (4) -->  Gross and net pay calculation
def salary_calculator():
    gross = float(input("Enter gross pay: "))
    net = gross * 0.8
    print(f"Net pay after 20% tax: {net:.2f}")

# (5) -->  Print numbers from 1 to 10
def print_numbers():
    for i in range(1, 11):
        print(i, end=' ')
    print()

# (6) -->  Accept input until negative number
def input_until_negative():
    while True:
        num = int(input("Enter a number: "))
        if num < 0:
            break

# (7) -->  Check range
def check_range():
    num = int(input("Enter an integer: "))
    if 0 <= num <= 10:
        print("Range 1")
    elif 11 <= num <= 20:
        print("Range 2")
    elif 21 <= num <= 30:
        print("Range 3")
    elif 31 <= num <= 40:
        print("Range 4")
    else:
        print("Out of range")

# -------------------------
# Strings Section
# -------------------------

# (1) -->  Reverse a string
def reverse_string():
    s = input("Enter a string: ")
    print("Reversed string:", s[::-1])

# (2) -->  Count upper and lower case
def count_case_letters():
    s = input("Enter a string: ")
    upper = sum(1 for c in s if c.isupper())
    lower = sum(1 for c in s if c.islower())
    print("Upper case letters:", upper)
    print("Lower case letters:", lower)

# (3) -->  Palindrome check
def is_palindrome():
    s = input("Enter a string: ").replace(" ", "").lower()
    print("Palindrome" if s == s[::-1] else "Not a palindrome")

# -------------------------
# Lists Section
# -------------------------

# (1) -->  Distinct elements
def unique_list(lst):
    return list(set(lst))

# (2) -->  Even numbers in a list
def even_numbers_from_list(lst):
    return [x for x in lst if x % 2 == 0]

# (3) -->  kth largest element
def kth_largest(lst, k):
    return sorted(lst, reverse=True)[k - 1]

# (4) -->  List palindrome check
def is_list_palindrome(lst):
    return lst == lst[::-1]

# (5) & (6) -->  Shopping list and insertion
def shopping_list_demo():
    items = ["apple", "bread", "milk", "eggs", "cheese", "butter", "rice", "meat", "fish", "juice"]
    print("Full list:", items)
    print("Item 2:", items[1])
    print("Item 8:", items[7])
    new_item = input("Enter an item to insert: ")
    items.append(new_item)
    print("Updated list:", items)

# -------------------------
# Dictionary Section
# -------------------------

# (1) -->  Sort dictionary by value
def sort_dict_by_value(d):
    asc = dict(sorted(d.items(), key=lambda x: x[1]))
    desc = dict(sorted(d.items(), key=lambda x: x[1], reverse=True))
    return asc, desc

# (2) -->  Check if key exists
def key_exists(d, key):
    return key in d

# (3) -->  Iterate dictionary
def iterate_dict(d):
    for k, v in d.items():
        print(f"{k} : {v}")

# (4) -->  Generate squares
def squares_dict(n):
    return {x: x**2 for x in range(1, n+1)}

# (5) -->  Employee dictionary
def employee_data():
    employees = {}
    while True:
        eid = input("Enter employee ID (or 'done'): ")
        if eid == "done":
            break
        name = input("Enter name: ")
        employees[eid] = name
    print("Employee Records:", employees)

# -------------------------
# Functions Section
# -------------------------

# (1) -->  Square function
def square_number():
    n = float(input("Enter a number: "))
    def square(x): return x ** 2
    print("Square:", square(n))

# (2) -->  Largest of two
def largest_of_two():
    a = float(input("Enter first number: "))
    b = float(input("Enter second number: "))
    def max_num(x, y): return x if x > y else y
    print("Largest is:", max_num(a, b))

# -------------------------
# OOP Section
# -------------------------

# (1) -->  Circle class
class Circle:
    def __init__(self, r):
        self.r = r

    def area(self):
        return 3.14159 * self.r ** 2

    def perimeter(self):
        return 2 * 3.14159 * self.r

# (2) -->  Person class
from datetime import datetime
class Person:
    def __init__(self, name, country, dob):
        self.name = name
        self.country = country
        self.dob = datetime.strptime(dob, "%Y-%m-%d")

    def age(self):
        today = datetime.today()
        return today.year - self.dob.year - ((today.month, today.day) < (self.dob.month, self.dob.day))

# (3) -->  Calculator class
class Calculator:
    def add(self, a, b): return a + b
    def subtract(self, a, b): return a - b
    def multiply(self, a, b): return a * b
    def divide(self, a, b): return a / b if b != 0 else "Division by zero"

# (4) -->  Shape hierarchy
class Shape:
    def area(self): pass
    def perimeter(self): pass

class Square(Shape):
    def __init__(self, s): self.s = s
    def area(self): return self.s ** 2
    def perimeter(self): return 4 * self.s

class Triangle(Shape):
    def __init__(self, a, b, c): self.a, self.b, self.c = a, b, c
    def perimeter(self): return self.a + self.b + self.c
    def area(self):  # Heron's formula
        s = self.perimeter() / 2
        return (s*(s-self.a)*(s-self.b)*(s-self.c))**0.5

