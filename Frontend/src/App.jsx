import { useEffect, useState } from "react";

function App() {
  const [requests, setRequests] = useState([]);
  const [loading, setLoading] = useState(true);

  const fetchRequests = async () => {
    try {
      const response = await fetch(
        "http://localhost:5006/api/ServiceRequests"
      );

      if (!response.ok) {
        throw new Error("Failed to fetch requests");
      }

      const data = await response.json();
      setRequests(data);
    } catch (error) {
      console.error("Error:", error);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchRequests();
  }, []);

  return (
    <div className="app">
      <header className="header">
        <h1>Smart Service Request Management</h1>
        <p>Manage and track service requests</p>
      </header>

      <main className="container">
        <div className="top-section">
          <h2>Service Requests</h2>
          <button>+ New Request</button>
        </div>

        {loading ? (
          <p>Loading requests...</p>
        ) : requests.length === 0 ? (
          <p>No service requests found.</p>
        ) : (
          <div className="request-grid">
            {requests.map((request) => (
              <div className="request-card" key={request.id}>
                <div className="card-header">
                  <h3>{request.title}</h3>

                  <span
                    className={`priority ${request.priority.toLowerCase()}`}
                  >
                    {request.priority}
                  </span>
                </div>

                <p className="description">
                  {request.description}
                </p>

                <div className="details">
                  <p>
                    <strong>Status:</strong>{" "}
                    <span className="status">
                      {request.status}
                    </span>
                  </p>

                  <p>
                    <strong>User:</strong>{" "}
                    {request.user?.name || "Unknown"}
                  </p>

                  <p>
                    <strong>Assigned To:</strong>{" "}
                    {request.assignedTo || "Not Assigned"}
                  </p>
                </div>

                <div className="card-actions">
                  <button className="edit-btn">Edit</button>
                  <button className="delete-btn">Delete</button>
                </div>
              </div>
            ))}
          </div>
        )}
      </main>
    </div>
  );
}

export default App;