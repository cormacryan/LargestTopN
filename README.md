# LargestTopN
Algorithm to return the N largest number of integers from a large text file.

This algorithm uses the built in List collection class from Microsoft in handling the time complexity of the sort, 
insert, lookup and add operations. The following Time complexity of the List collection operations is as follows.

List Class      // Internal underlying implementaiton of Array structure.<br>
List.Add()      // Time complexity of O(1)<br>
List.RemoveAt() // Time complexity of O(n)<br>
List.Item[i]    // Time complexity of O(1)<br>
List.Sort()     // Quick Sort algorithm on average O(n log n), worst case O(n ^ 2)<br>

Format of the algorithm is as follows:<br>

1. Read in the first top N elements from the file.<br>
2. Sort the array from largest to smallest.<br>
3. Read in the rest of the numbers line by line.
4. For each of the remaining numbers perform the following.
5. If the number read is less than the last smallest number in the array ignore and continue to read Otherwise add this number to the array.<br>
6. Sort the array from largest to smallest to find the correct position of the newly inserted element.
7. Remove the last current smallest element from the array to get back to the TOP N size of elements.

A better solution is to potentially remove the current sorting implementation and use a BINARY HEAP to handle the order and sorting of the array elements. The time complexity to implement this would be of O(n log k).

1. First k elements added to the heap in O(k).
2. Time to process each of the remaining elements or O(1)
3. Test, delete and insert if the element needs to be added or removed is of O(log k)
4. Total time overall is O(k+(n-k)log k) or O(n log k)

Further analysis to potentially reduce this further could be implemented using a an algorithm called quickselect which is based of the quicksort algorithm.

