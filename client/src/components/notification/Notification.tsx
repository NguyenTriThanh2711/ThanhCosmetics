import { useEffect, useState } from "react";

import { useStore } from "../../store";

import "./Notification.scss";
import { Alert, Snackbar } from "@mui/material";

const Notification = () => {
  const notification = useStore((state) => state.notification.data);
  const [item, setItem] = useState<{ status: string; content: string } | null>(null);
  const [open, setOpen] = useState(false);

  useEffect(() => {
    if (notification.length > 0) {
      const lastItem = notification[notification.length - 1];
      setItem(lastItem);
      setOpen(true);
    }
  }, [notification]);

  return (
    <Snackbar
      anchorOrigin={{ vertical: "top", horizontal: "center" }}
      open={open}
      autoHideDuration={2000}
      onClose={() => setOpen(false)}
    >
      {item?.status === "ERROR" ? (
        <Alert severity="error">{item?.content}</Alert>
      ) : (
        <Alert severity="success">{item?.content}</Alert>
      )}
    </Snackbar>
  );
};

export default Notification;