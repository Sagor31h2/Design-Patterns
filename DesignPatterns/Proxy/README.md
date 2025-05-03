# **Proxy Pattern Summary**

#### **1. Problem Statement**

Imagine you are working on a system where you need to access an object that is resource-intensive to create, lives on a remote server, or requires access control. For example:

* A large image that takes time to load
* An object that resides on another machine
* Sensitive operations that must be permission-checked

**Challenges with a naive approach:**

* **Performance**: Expensive objects may be created even when not used.
* **Security**: Clients might access methods they shouldn’t.
* **Tight Coupling**: Clients may need to know too much about the real object or its remote location.

---

#### **2. Proxy Pattern Solution**

The **Proxy Pattern** provides a surrogate or placeholder for another object to control access to it.
The proxy implements the same interface as the real object, so clients use it transparently.

---

#### **3. Types of Proxies**

1. **Virtual Proxy** – Controls access to a resource that is expensive to create (e.g., lazy-loads large images).
2. **Remote Proxy** – Acts as a local representative for an object that lives in a different address space (e.g., in another machine).
3. **Protection Proxy** – Controls access based on permissions (e.g., restricts method access depending on user role).
4. **Smart Proxy** – Adds extra behaviors when accessing an object (e.g., reference counting, logging, etc.).

---

#### **4. Participants in the Proxy Pattern**

1. **Subject (Interface)**

   * Declares common operations for the `RealSubject` and the `Proxy`.

2. **RealSubject**

   * Implements actual business logic.

3. **Proxy**

   * Implements the same interface as `RealSubject`.
   * Controls access to the `RealSubject`.

4. **Client**

   * Uses the `Subject` interface to interact with the object, whether it’s the proxy or the real subject.

---

#### **5. C# Code Example (Virtual Proxy - Image Viewer)**

---

**Step 1: Subject Interface**

```csharp
public interface IImage
{
    void Display();
}
```

---

**Step 2: RealSubject (Heavy Object)**

```csharp
public class RealImage : IImage
{
    private readonly string _filename;

    public RealImage(string filename)
    {
        _filename = filename;
        LoadFromDisk(); // Expensive operation
    }

    private void LoadFromDisk()
    {
        Console.WriteLine($"Loading image from disk: {_filename}");
    }

    public void Display()
    {
        Console.WriteLine($"Displaying image: {_filename}");
    }
}
```

---

**Step 3: Proxy**

```csharp
public class ProxyImage : IImage
{
    private readonly string _filename;
    private RealImage _realImage;

    public ProxyImage(string filename)
    {
        _filename = filename;
    }

    public void Display()
    {
        if (_realImage == null)
        {
            _realImage = new RealImage(_filename);
        }
        _realImage.Display();
    }
}
```

---

**Step 4: Client Code**

```csharp
class Program
{
    static void Main()
    {
        IImage image = new ProxyImage("design-patterns.png");

        // Image will be loaded and displayed
        image.Display();

        Console.WriteLine();

        // Image already loaded, only display
        image.Display();
    }
}
```

---

#### **6. Output**

```
Loading image from disk: design-patterns.png
Displaying image: design-patterns.png

Displaying image: design-patterns.png
```

---

#### **7. Benefits of the Proxy Pattern**

* **Lazy Initialization**: Virtual proxies defer resource loading.
* **Access Control**: Protection proxies enforce user permissions.
* **Separation of Concerns**: Keeps the client unaware of whether it’s using a proxy or the real object.
* **Network Transparency**: Remote proxies simplify client-side code for distributed systems.

---

#### **8. Trade-offs**

* **Added Complexity**: Introduces more classes to manage.
* **Potential Overhead**: Some proxies (especially remote) may introduce latency.
* **Maintenance Overhead**: Proxy must mirror the interface of the real object.

---

#### **9. Real-World Uses**

* **Virtual Proxy**: Image loading in GUI applications.
* **Remote Proxy**: Java RMI, .NET Remoting, gRPC clients.
* **Protection Proxy**: Role-based access control systems.
* **Smart Proxy**: Resource pooling or usage tracking.
