## Requirements
- The application will be implemented in .NET version 3.5 or higher.

## Task formulation
- Implement a console application that will be composed of a fifo queue of strings and two threads fighting to dequeue from the queue.

## Queue specifications
- The queue will be a wrapper of a List<string> generic collection. It will have the following public methods:
    - <b>public void Enqueue(string item)</b>: Add an item to the list.
    - <b>public string Dequeue()</b>: Return and remove the last item of the list.
    - <b>public int Count()</b>: Get the number of items in the list.
- When an element is enqueued, the event <b>OnItemEnqueued</b> will be fired.
- Remember that List<T> is not thread-safe.

## Fighting Threads

- Create two instances of <b>System.Thread</b> named "t1" and "t2" executing the following method:
    - <b>public string Consume()</b>: This method will have an inifinite loop that will dequeue elements from the queue until it is empty. Every time an element is dequeued it will be printed in the console along with the name of the thread. Once the queue is empty, the method will wait to receive a signal to start dequeueing elements again. The signal will be fired by the implementation of the event <b>OnItemEnqueued</b>. This signal should start all sleeping threads.

## Testing method
- You may want to write a method in the main process to populate the queue.

## Evaluation goals
- Neat and quality code.
- Usage of .NET multithreading namespaces.