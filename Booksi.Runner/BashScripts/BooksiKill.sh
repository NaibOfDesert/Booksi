#!/bin/bash

echo "Started ... BooksiKill.sh"

lsof -i tcp:5231

#! to change PID number
kill -9 67772